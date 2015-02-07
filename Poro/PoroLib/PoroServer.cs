using LiteDB;
using Newtonsoft.Json;
using PoroLib.Forwarder;
using PoroLib.Forwarder.Shards;
using PoroLib.Messages;
using PoroLib.Redirector;
using PoroLib.Structures;
using PoroLib.Users;
using RtmpSharp.IO;
using RtmpSharp.Messaging;
using RtmpSharp.Messaging.Messages;
using RtmpSharp.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoroLib
{
    public class PoroServer
    {
        private static string _clientVersion = "";
        public static string ClientVersion { get { return _clientVersion; } set { _clientVersion = value; } }

        private PoroServerSettings _settings;
        private SerializationContext _context;
        private AuthServer _auth;
        private RtmpServer _server;
        private MessageHandler _handler;
        private MessageForwarder _forwarder;
        private PropertyRedirector _redirector;
        private UserHandler _users;

        public PoroServer(PoroServerSettings settings)
        {
            _settings = settings;

            //Create the Authentication Server to handle login requests and client page
            _auth = new AuthServer(HandleWebServ, _settings.AuthLocations);

            //Load the certificate for the RTMPS server
            var certificateStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            certificateStore.Open(OpenFlags.MaxAllowed);

            //Store the certificate if it's not in the local store
            var _rtmpsCert = new X509Certificate2(_settings.CertFilename, "");
            if (!StoreContainsCertificate(certificateStore.Certificates, _rtmpsCert))
                certificateStore.Add(_rtmpsCert);
            certificateStore.Close();

            //Generate the SerializationContext
            _context = new SerializationContext();
            var structures = Assembly.GetExecutingAssembly().GetTypes().Where(x => String.Equals(x.Namespace, "PoroLib.Structures", StringComparison.Ordinal));

            foreach (Type ObjectType in structures)
                _context.Register(ObjectType);

            //Create the RTMPS server with the context and certificate
            _server = new RtmpServer(new IPEndPoint(IPAddress.Parse(_settings.RTMPSHost), _settings.RTMPSPort), _context, _rtmpsCert);
            _server.ClientCommandReceieved += ClientCommandReceieved;
            _server.ClientMessageReceived += ClientMessageReceived;

            //Set up the handler
            _handler = new MessageHandler();
            _handler.Register("LoginService");
            _handler.Register("MatchmakerService");
            _handler.Register("ClientFacadeService");
            _handler.Register("InventoryService");
            _handler.Register("MasteryBookService");
            _handler.Register("SummonerRuneService");
            _handler.Register("PlayerPreferencesService");
            _handler.Register("LcdsGameInvitationService");
            _handler.Register("SummonerTeamService");

            //Set up the forwarder
            _forwarder = new MessageForwarder(_context);

            //Set up the property redirector
            _redirector = new PropertyRedirector(_settings);

            //Set up the user server
            _users = new UserHandler();
        }

        void ClientMessageReceived(object sender, RemotingMessageReceivedEventArgs e)
        {
            Console.WriteLine(string.Format("[LOG] Request for {0} at destination {1}", e.Operation, e.Destination));

            //Forward message to connected server
            RemotingMessageReceivedEventArgs tempRecv = null;
            if (_forwarder.Forwarding)
            {
                var handleTask = _forwarder.Handle(sender, e);
                Task.WaitAll(handleTask);
                tempRecv = handleTask.Result;
            }

            //Handle locally
            if (tempRecv == null)
                tempRecv = _handler.Handle(sender, e);

            //If no handling is possible, throw an exception
            if (tempRecv == null)
                throw new Exception(string.Format("Bad request for {0} at destination {1}", e.Operation, e.Destination));

            e = tempRecv;
        }

        public void Start()
        {
            Console.WriteLine("[LOG] AuthServer listening on port 8080");
            _auth.Start();

            Console.WriteLine("[LOG] RTMPS Server listening at rtmps://{0}:{1}", _settings.RTMPSHost, _settings.RTMPSPort);
            _server.Listen();
        }

        bool StoreContainsCertificate(X509Certificate2Collection collection, X509Certificate2 certificate)
        {
            var CertificateList = (from X509Certificate2 cert in collection select GetCommonName(cert)).ToList();
            return CertificateList.Contains(GetCommonName(certificate));
        }

        string GetCommonName(X509Certificate2 cert)
        {
            return cert.GetNameInfo(X509NameType.SimpleName, false);
        }

        public async Task<object> HandleWebServ(HttpListenerRequest request)
        {
            //TODO: not have this data stored in code
            if (request.RawUrl.Contains("login-queue"))
            {
                return "{\"rate\":75,\"reason\":\"login_rate\",\"status\":\"LOGIN\",\"lqt\":{\"other\":\"\",\"fingerprint\":\"\",\"signature\":\"\",\"timestamp\":1418934199554,\"uuid\":\"\",\"resources\":\"lol\",\"account_id\":200006292,\"account_name\":\"snowl\"},\"delay\":10000,\"inGameCredentials\":{\"inGame\":false,\"summonerId\":null,\"serverIp\":null,\"serverPort\":null,\"encryptionKey\":null,\"handshakeToken\":null},\"user\":\"snowl\"}";
            }
            else
            {
                #region API
                if (request.RawUrl.StartsWith("/api"))
                {
                    //TODO: Create API handler
                    if (request.RawUrl.StartsWith("/api/users"))
                    {
                        return JsonConvert.SerializeObject(_users.GetUserList());
                    }
                    else if (request.RawUrl.StartsWith("/api/register"))
                    {
                        if (request.QueryString == null && request.QueryString.Count != 4)
                            return "400";

                        _users.AddUser(new User
                        {
                            Username = request.QueryString["Username"],
                            Password = request.QueryString["Password"],
                            Region = request.QueryString["Region"],
                            SummonerName = request.QueryString["Username"]
                        });
                        return JsonConvert.SerializeObject(_users.GetUserList());
                    }
                    else if (request.RawUrl.StartsWith("/api/delete"))
                    {
                        if (request.QueryString == null && request.QueryString.Count != 2)
                            return "400";

                        User u = _users.GetUser(request.QueryString["Username"], request.QueryString["Region"]);
                        _users.RemoveUser(u);

                        return JsonConvert.SerializeObject(_users.GetUserList());
                    }
                    else if (request.RawUrl.StartsWith("/api/regions"))
                    {
                        return JsonConvert.SerializeObject(Shards.GetStatus());
                    }
                    else if (request.RawUrl.StartsWith("/api/login"))
                    {
                        if (request.QueryString == null && request.QueryString.Count != 2)
                            return "400";

                        string Username = request.QueryString["Username"];
                        string Region = request.QueryString["Region"];

                        var ShardList = Shards.GetInstances<BaseShard>();
                        BaseShard shard = null;
                        foreach (BaseShard s in ShardList)
                            if (s.Name == Region)
                                shard = s;

                        User user = _users.GetUser(Username, Region);
                        ForwardPlayer player = new ForwardPlayer(user, shard, _context);
                        bool Connected = await player.Connect(user, shard);

                        _forwarder.Assign(player);

                        return JsonConvert.SerializeObject("OK");
                    }
                    else
                    {
                        return "404";
                    }
                }
                #endregion

                string ReadURL = request.RawUrl;
                if (ReadURL == "/")
                    ReadURL = "/index.html";
                if (ReadURL == "/favicon.ico")
                    return "";

                string ContentType = AuthServer.SetContentType(request.RawUrl);
                string FileURL = string.Format("app/web{0}", ReadURL);

                string RequestedFile = FileURL.Split('/').Last();
                //Store current webpage in file
                /*var x = File.OpenRead(FileURL);
                using (var db = new LiteEngine("poro.dat"))
                {
                    var rte = db.FileStorage.All();
                    db.FileStorage.Upload(RequestedFile, x);
                }*/

                using (var db = new LiteEngine("poro.dat"))
                {
                    var file = db.FileStorage.FindById(RequestedFile);

                    if (file == null)
                        return "404";

                    var stream = file.OpenRead();

                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        byte[] bytes = memoryStream.ToArray();
                        if (ContentType.StartsWith("image"))
                        {
                            return bytes;
                        }
                        else
                        {
                            return Encoding.Default.GetString(bytes);
                        }
                    }
                }
                
                //Read direct from file system
                /*if (ContentType.StartsWith("image"))
                {
                    return File.ReadAllBytes(FileURL);
                }
                else
                {
                    return File.ReadAllText(FileURL);
                }*/
            }
        }

        public static List<T> GetInstances<T>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.BaseType == typeof(T) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T)Activator.CreateInstance(t)).ToList();
        }

        void ClientCommandReceieved(object sender, CommandMessageReceivedEventArgs e)
        {
            RtmpClient client = sender as RtmpClient;

            if (e.Message.Operation == CommandOperation.Login)
            {
                ClientDynamicConfigurationNotification clientConfig = new ClientDynamicConfigurationNotification
                {
                    Delta = false,
                    //TODO: not have this data stored in code
                    Config = "{\"PlatformShutdown\":{\"Enabled\":false},\"BotConfigurations\":{\"IntermediateInCustoms\":true},\"ShareMatchHistory\":{\"MatchHistoryUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#login?redirect=%23player-search%2FcurrentAccount%2FOC1%2F{0}\",\"AdvancedGameDetailsUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#match-details/OC1/{0}/{1}/eog\",\"AdvancedGameDetailsEnabled\":true,\"MatchDetailsUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#match-details/OC1/{0}/{1}\",\"ShareEndOfGameEnabled\":true,\"ShareGameUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#match-details/OC1/{0}/{1}/eog\",\"MatchHistoryEnabled\":true},\"GuestSlots\":{\"Enabled\":null},\"ServiceStatusAPI\":{\"Enabled\":true},\"GameTimerSync\":{\"Enabled\":false,\"PercentOfTotalTimerToSyncAt\":0.8},\"QueueRestriction\":{\"ServiceEnabled\":true,\"RankedDuoQueueRestrictionMode\":\"TIER\",\"KarmaEnabled\":false,\"RankedDuoQueueRestrictionMaxDelta\":1,\"RankedDuoQueueDefaultUnseededTier\":\"SILVER\"},\"DockedPrompt\":{\"EnabledNewDockedPromptRenderer\":true},\"QueueImages\":{\"OverrideQueueImage\":true},\"SuggestedPlayers\":{\"HonoredPlayersLimit\":4,\"FriendsOfFriendsLimit\":22,\"Enabled\":true,\"OnlineFriendsLimit\":4,\"PreviousPremadesLimit\":4,\"MaxNumSuggestedPlayers\":8,\"VictoriousComradesLimit\":4,\"FriendsOfFriendsEnabled\":true,\"MaxNumReplacements\":22},\"DisabledChampions\":{\"FIRSTBLOOD\":\"[]\",\"KINGPORO\":\"[161]\",\"ARAM_UNRANKED_5x5\":\"[]\",\"ONEFORALL_5x5\":\" []\",\"ASCENSION\":\"[83]\",\"SR_6x6\":\"[]\",\"URF\":\"[120,16,76,12,10,72,13,38,37]\",\"KING_PORO\":\"[161]\",\"ODIN_UNRANKED\":\"[]\",\"NIGHTMARE_BOT\":\"[]\",\"RANKED_SOLO_5x5\":\"[]\",\"TUTORIAL\":\"[]\",\"URF_BOT\":\"[]\",\"FIRSTBLOOD_2x2\":\"[]\",\"FIRSTBLOOD_1x1\":\"[]\",\"CLASSIC\":\"[]\",\"RANKED_TEAM_5x5\":\"[]\",\"RANKED_TEAM_3x3\":\"[]\",\"HEXAKILL\":\"[]\",\"BOT\":\"[]\",\"ODIN\":\"[]\",\"ONEFORALL\":\"[]\",\"NORMAL\":\"[]\",\"NORMAL_3x3\":\"[]\",\"BOT_3x3\":\"[]\",\"ARAM\":\"[]\"},\"Mutators\":{\"EnabledMutators\":\"[]\",\"EnabledModes\":\"[\\\"CLASSIC\\\",\\\"TUTORIAL\\\",\\\"ODIN\\\",\\\"ARAM\\\",\\\"KINGPORO\\\"]\"},\"EndOfGameGifting\":{\"Enabled\":true},\"SkinRentals\":{\"Enabled\":\"PROCESSONLY\"},\"ContextualEducation\":{\"TargetMinionsPerWave\":0.4,\"Enabled\":false,\"MaxTargetSummonerLevel\":10.0},\"DisabledChampionSkins\":{\"DisabledChampionSkins\":\"[]\"},\"EndOfGameGiftSettings\":{\"SenderGiftDailyMax\":5,\"GiftRecipientLevelMin\":5,\"GiftSenderRPMax\":50000,\"RecipientGiftDailyMax\":5,\"GiftSenderLevelMin\":15},\"Chat\":{\"Rename_general_group_throttle\":1.0,\"Default_public_chat_rooms\":\"\"},\"GameInvites\":{\"ServiceEnabled\":true,\"InviteBulkMaxSize\":200,\"LobbyCreationEnabled\":true},\"ContextualEducationURLs\":{\"LAST_HIT\":\"null\"},\"NewPlayerRouter\":{\"QueueID\":\"31\",\"ABDisablingOfTutorial\":true},\"SeasonReward\":{\"Maximum_team_reward_level\":3,\"Enabled\":true,\"ServiceCallEnabled\":true,\"QualificationWarningEnabled\":false,\"Minimum_points_per_reward_level\":\"20,45,75\",\"Minimum_win_team_reward_level_2\":35,\"Minimum_win_team_reward_level_1\":10,\"Minimum_win_team_reward_level_3\":75},\"String\":{\"String\":null},\"LeagueConfig\":{\"IsPreseason\":true,\"MasterTierEnabled\":true,\"PreseasonName\":\"2015\",\"SeasonName\":\"2014\"},\"ChampionTradeService\":{\"Enabled\":true},\"ChampionSelect\":{\"UseOptimizedChampSelectProcessor\":false,\"UseOptimizedSpellSelectProcessor\":false,\"AllChampsAvailableInAram\":false,\"UseOptimizedBotChampionSelectProcessor\":false,\"AutoReconnectEnabled\":false,\"CollatorChampionFilterEnabled\":false},\"FeaturedGame\":{\"MetadataEnabled\":\"OFF\"}}"
                };

                client.InvokeDestReceive("cn-1", "cn-1", "messagingDestination", clientConfig);
            }

            /*var tempCommand = _forwarder.HandleCommand(sender, e);

            Task.WaitAll(tempCommand);

            RtmpClient client = sender as RtmpClient;
            client.InvokeResult(e.InvokeId, e.Message.CorrelationId, tempCommand);*/
        }
    }
}
