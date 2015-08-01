using LiteDB;
using Newtonsoft.Json;
using PoroLib.Certificate;
using PoroLib.Data;
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
using System.Threading.Tasks;
//using XMPPP;

namespace PoroLib
{
    public class PoroServer
    {
        private static string _clientVersion = "5.14.15_07_17_17_29";
        public static string ClientVersion { get { return _clientVersion; } set { _clientVersion = value; } }
        private static string _clientLocation = "";
        public static string ClientLocation { get { return _clientLocation; } set { _clientLocation = value; } }

        internal static DataLoader _data;

        private PoroServerSettings _settings;
        private SerializationContext _context;
        private AuthServer _auth;
        private RtmpServer _server;
        private MessageHandler _handler;
        private MessageForwarder _forwarder;
        private PropertyRedirector _redirector;
        private UserHandler _users;
        //private XMPPServer _chat;

        public PoroServer(PoroServerSettings settings)
        {
            _settings = settings;

            //Create the Authentication Server to handle login requests and client page
            _auth = new AuthServer(HandleWebServ, _settings.AuthLocations);

            //Load the certificate store for the RTMPS server
            var certificateStore = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);
            certificateStore.Open(OpenFlags.MaxAllowed);

            //Remove last certificate in case it wasn't deleted on close
            foreach (var cert in certificateStore.Certificates)
            {
                if (cert.IssuerName.Name == string.Format("CN={0}", _settings.RTMPSHost))
                {
                    certificateStore.Remove(cert);
                }
            }

            //Generate new certificate for this run and add it to the store.
            var _rtmpsCert = CertGen.CreateSelfSignedCertificate(_settings.RTMPSHost);
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
            _handler.Register("LeaguesServiceProxy");

            //Set up the forwarder
            _forwarder = new MessageForwarder(_context);

            //Set up the property redirector
            _redirector = new PropertyRedirector(_settings);

            //Set up the data loader
            _data = new DataLoader();
            _redirector.PatcherFound += new PropertyRedirector.PatcherFoundHandler(_data.LoadData);

            //Set up the user server
            _users = new UserHandler();

            //Set up the chat server
            //_chat = new XMPPServer(new IPEndPoint(IPAddress.Parse(_settings.RTMPSHost), 5223), _rtmpsCert);
        }

        void ClientMessageReceived(object sender, RemotingMessageReceivedEventArgs e)
        {
            bool wasForwarded = false;

            //Forward message to connected server
            RemotingMessageReceivedEventArgs tempRecv = null;
            if (_forwarder.Forwarding && e.Operation != "login")
            {
                var handleTask = _forwarder.Handle(sender, e);

                //Wait for Riot's server to respond
                Task.WaitAll(handleTask); 

                tempRecv = handleTask.Result;
                wasForwarded = true;
            }

            //Handle locally if it wasn't forwarded
            if (tempRecv == null)
                tempRecv = _handler.Handle(sender, e);

            LogRequest(tempRecv, e, wasForwarded);

            e = tempRecv;
        }

        void LogRequest(RemotingMessageReceivedEventArgs tempRecv, RemotingMessageReceivedEventArgs e, bool wasForwarded)
        {
            string forwardMessage = " [Forwarded]";

            if (!wasForwarded)
                forwardMessage = "";

            if (tempRecv == null)
                Console.WriteLine(string.Format("[LOG] Bad request for {0} : {1}{2}", e.Operation, e.Destination, forwardMessage));
            else
                Console.WriteLine(string.Format("[LOG] Request for {0} : {1}{2}", e.Operation, e.Destination, forwardMessage));
        }

        public void Start()
        {
            Console.WriteLine("[LOG] AuthServer listening on port 8080");
            _auth.Start();

            Console.WriteLine("[LOG] RTMPS Server listening at rtmps://{0}:{1}", _settings.RTMPSHost, _settings.RTMPSPort);
            _server.Listen();

            //Console.WriteLine("[LOG] Chat Server listening at xmpp://{0}:{1}", _settings.RTMPSHost, 5223);
            //_chat.Listen();
        }

        public async Task<object> HandleWebServ(HttpListenerRequest request)
        {
            if (request.RawUrl.Contains("login-queue"))
            {
                return "{\"status\":\"LOGIN\"}";
            }
            else if (request.RawUrl.StartsWith("/api"))
            {
                return await HandleAPI(request);
            }
            else
            {

                string ReadURL = request.RawUrl;
                if (ReadURL == "/")
                    ReadURL = "/index.html";
                if (ReadURL == "/favicon.ico")
                    return "";

                string ContentType = AuthServer.SetContentType(request.RawUrl);
                string RequestedFile = ReadURL.Split('/').Last();

#if !FILESYSTEM
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
#endif
      
#if FILESYSTEM
                //Uncomment to create poro.dat
                /*var x = File.OpenRead(FileURL);
                using (var db = new LiteEngine("poro.dat"))
                {
                    var file = db.FileStorage.FindById(RequestedFile);

                    if (file == null)
                    {
                        db.FileStorage.Upload(RequestedFile, x);
                    }
                }*/

                string FileURL = string.Format("app/web{0}", ReadURL);

                if (ContentType.StartsWith("image"))
                {
                    return File.ReadAllBytes(FileURL);
                }
                else
                {
                    return File.ReadAllText(FileURL);
                }
#endif
            }
        }

        public async Task<object> HandleAPI(HttpListenerRequest request)
        {
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
                bool Connected = await player.Connect();

                foreach (RtmpClient client in _server.Clients)
                {
                    StoreAccountBalanceNotification notification = new StoreAccountBalanceNotification
                    {
                        IP = player._packet.IpBalance,
                        RP = player._packet.RpBalance
                    };

                    client.InvokeDestReceive("cn-1", "cn-1", "messagingDestination", notification);
                }

                _forwarder.Assign(player);

                Console.WriteLine(string.Format("[LOG] Forwarding to {0} ({1})", Username, Region));

                return JsonConvert.SerializeObject("OK");
            }
            else if (request.RawUrl.StartsWith("/api/check"))
            {
                if (_forwarder.Forwarding)
                    return JsonConvert.SerializeObject(_forwarder._client._user);
                else
                    return JsonConvert.SerializeObject("Not logged in");
            }
            else
            {
                return "404";
            }
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
                    Config = "{\"Chroma\":{\"IsEnabled\":true},\"PlatformShutdown\":{\"Enabled\":false},\"BotConfigurations\":{\"IntermediateInCustoms\":true},\"ShareMatchHistory\":{\"MatchHistoryUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#login?redirect=%23player-search%2FcurrentAccount%2FOC1%2F{0}\",\"AdvancedGameDetailsUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#match-details/OC1/{0}/{1}/eog\",\"AdvancedGameDetailsEnabled\":true,\"MatchDetailsUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#match-details/OC1/{0}/{1}\",\"ShareEndOfGameEnabled\":true,\"ShareGameUrlTemplate\":\"http://matchhistory.oce.leagueoflegends.com/{2}/#match-details/OC1/{0}/{1}/eog\",\"MatchHistoryEnabled\":true},\"GuestSlots\":{\"Enabled\":null},\"ServiceStatusAPI\":{\"Enabled\":true},\"FriendRecommendations\":{\"FaqLink\":\"http://oce.leagueoflegends.com/en/page/faq-add-friends\",\"StatusExpiryMillis\":300000,\"EnableAddFriendButton\":true,\"EnabledPercent\":100,\"ShowToolTip\":true,\"RegistrationPollRateMillis\":5000,\"HideFriends\":false,\"PlayerLevelForNewNotification\":0,\"RegistrationPollDurationMillis\":300000,\"ContactsUrlTemplate\":\"https://recofriender.leagueoflegends.com/v1/contacts/{0}/{1}\",\"ContactDetailsUrlTemplate\":\"https://recofriender.leagueoflegends.com/v1/contactdetails/{0}/{1}/{2}/\",\"AssociationUrlTemplate\":\"https://recofriender.leagueoflegends.com/v1/facebook-oauth?locale={0}\",\"EnableViewAllPanel\":true,\"UnlinkUrlTemplate\":\"https://recofriender.leagueoflegends.com/v1/facebook-oauth/unlink/{0}/{1}\",\"UseNativeFacebookPop\":false},\"GameTimerSync\":{\"Enabled\":false,\"PercentOfTotalTimerToSyncAt\":0.8},\"DockedPrompt\":{\"EnabledNewDockedPromptRenderer\":true},\"QueueRestriction\":{\"ServiceEnabled\":true,\"RankedDuoQueueRestrictionMode\":\"TIER\",\"KarmaEnabled\":false,\"RankedDuoQueueRestrictionMaxDelta\":1,\"RankedDuoQueueDefaultUnseededTier\":\"SILVER\"},\"PartyRewards\":{\"Enabled\":false,\"GameFlowVisualUpdate\":false},\"QueueImages\":{\"OverrideQueueImage\":true},\"SuggestedPlayers\":{\"HonoredPlayersLimit\":4,\"FriendsOfFriendsLimit\":22,\"Enabled\":true,\"OnlineFriendsLimit\":4,\"PreviousPremadesLimit\":4,\"MaxNumSuggestedPlayers\":8,\"VictoriousComradesLimit\":4,\"FriendsOfFriendsEnabled\":true,\"MaxNumReplacements\":22},\"DisabledChampions\":{\"FIRSTBLOOD\":\"[]\",\"KINGPORO\":\"[161]\",\"ARAM_UNRANKED_5x5\":\"[]\",\"ONEFORALL_5x5\":\" []\",\"ASCENSION\":\"[83]\",\"SR_6x6\":\"[]\",\"BILGEWATER\":\"[]\",\"URF\":\"[]\",\"KING_PORO\":\"[161]\",\"ODIN_UNRANKED\":\"[]\",\"NIGHTMARE_BOT\":\"[]\",\"RANKED_SOLO_5x5\":\"[]\",\"TUTORIAL\":\"[]\",\"URF_BOT\":\"[]\",\"FIRSTBLOOD_2x2\":\"[]\",\"FIRSTBLOOD_1x1\":\"[]\",\"CLASSIC\":\"[]\",\"RANKED_TEAM_5x5\":\"[]\",\"COUNTER_PICK\":\"[]\",\"RANKED_TEAM_3x3\":\"[]\",\"HEXAKILL\":\"[]\",\"BOT\":\"[]\",\"ODIN\":\"[]\",\"ONEFORALL\":\"[]\",\"NORMAL\":\"[]\",\"NORMAL_3x3\":\"[]\",\"BOT_3x3\":\"[]\",\"ARAM\":\"[]\"},\"Mutators\":{\"CustomGameMutators\":\"[]\",\"BattleTrainingMutators\":\"[]\",\"EnabledMutators\":\"[\\\"Bilgewater\\\"]\",\"BasicTutorialMutators\":\"[\\\"BasicTutorial\\\"]\",\"EnabledModes\":\"[\\\"CLASSIC\\\",\\\"TUTORIAL\\\",\\\"ODIN\\\",\\\"ARAM\\\"]\"},\"EndOfGameGifting\":{\"Enabled\":true},\"ProfileHoverCard\":{\"IsEnabledForBuddyPanelView\":\"true\",\"ACSLookup\":\"true\",\"IsEnabledForSummonerQuickView\":\"true\",\"IsEnabledForGameLobbySuggestedPlayers\":\"true\",\"IsEnabledForGroupFinderCapViewSuggestedPlayers\":null,\"IsEnabledForChatFriendsList\":\"true\",\"IsEnabledForChatGroupChatParticipants\":\"true\",\"IsEnabledForCustomGameLobby\":\"true\",\"IsEnabled\":\"true\",\"ChampionMasteryLookup\":\"true\",\"IsEnabledForTeamBuilderSuggestedPlayers\":\"true\",\"LeagueLookup\":\"true\"},\"SkinRentals\":{\"Enabled\":\"ON\"},\"ContextualEducation\":{\"TargetMinionsPerWave\":0.4,\"Enabled\":false,\"MaxTargetSummonerLevel\":10.0},\"DisabledChampionSkins\":{\"DisabledChampionSkins\":\"[]\"},\"ChampionMasteryConfig\":{\"Enabled\":true,\"MinSummonerLevel\":5,\"EndOfGameEnabled\":true,\"SupportedQueueTypes\":\"RANKED_SOLO_5x5,RANKED_TEAM_5x5,CAP_5x5,NORMAL,BILGEWATER-5x5\",\"MaxChampionLevel\":5,\"ShowGradeAvailablePopup\":true,\"CapUnlockChampionLevel\":4,\"GradeEnabled\":true},\"EndOfGameGiftSettings\":{\"SenderGiftDailyMax\":5,\"GiftRecipientLevelMin\":5,\"GiftSenderRPMax\":50000,\"RecipientGiftDailyMax\":5,\"GiftSenderLevelMin\":15},\"GameInvites\":{\"ServiceEnabled\":true,\"InviteBulkMaxSize\":200,\"LobbyCreationEnabled\":true},\"Chat\":{\"Rename_general_group_throttle\":1.0,\"Default_public_chat_rooms\":\"\",\"MaximumRosterSize\":325},\"ContextualEducationURLs\":{\"LAST_HIT\":\"null\"},\"NewMatchHistory\":{\"Enabled\":true,\"PostIPXPToLegSEnabled\":true,\"SharingEnabled\":true},\"NewPlayerRouter\":{\"QueueID\":\"31\",\"ABDisablingOfTutorial\":true},\"SeasonReward\":{\"Maximum_team_reward_level\":3,\"Enabled\":true,\"ServiceCallEnabled\":true,\"QualificationWarningEnabled\":true,\"Minimum_points_per_reward_level\":\"20,45,75\",\"Minimum_win_team_reward_level_2\":35,\"Minimum_win_team_reward_level_1\":10,\"Minimum_win_team_reward_level_3\":75},\"String\":{\"String\":null},\"LeagueConfig\":{\"IsPreseason\":false,\"MasterTierEnabled\":true,\"PreseasonName\":\"2015\",\"SeasonName\":\"2015\"},\"ChampionTradeService\":{\"Enabled\":true},\"ChampionSelect\":{\"UseOptimizedChampSelectProcessor\":false,\"UseOptimizedSpellSelectProcessor\":false,\"AllChampsAvailableInAram\":false,\"UseOptimizedBotChampionSelectProcessor\":false,\"AutoReconnectEnabled\":true,\"CollatorChampionFilterEnabled\":false,\"AlwaysShowRewardIcon\":false},\"FeaturedGame\":{\"MetadataEnabled\":\"OFF\"},\"PlatfromShutdown\":{\"Enabled\":false}}"
                };

                client.InvokeDestReceive("cn-200006292", "cn-200006292", "messagingDestination", clientConfig);
            }
        }

        public static List<T> GetInstances<T>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.BaseType == typeof(T) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T)Activator.CreateInstance(t)).ToList();
        }
    }
}
