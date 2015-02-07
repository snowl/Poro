using Newtonsoft.Json;
using PoroLib.Forwarder.Shards;
using PoroLib.Structures;
using PoroLib.Users;
using RtmpSharp.IO;
using RtmpSharp.Messaging;
using RtmpSharp.Messaging.Messages;
using RtmpSharp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PoroLib.Forwarder
{
    public class ForwardPlayer
    {
        protected RtmpClient _client;
        protected double _accountId;
        protected double _summonerId;
        protected string _summonerName;

        public ForwardPlayer(User User, BaseShard Shard, SerializationContext Context)
        {
            _client = new RtmpClient(new Uri("rtmps://" + Shard.URL + ":2099"), Context, ObjectEncoding.Amf3);
            //_client.MessageReceived += Client_MessageReceived;
            //_client.CallbackException += Client_CallbackException;
        }

        public async Task<bool> Connect(User User, BaseShard Shard)
        {
            await _client.ConnectAsync();

            string password = DPAPI.Decrypt(User.Password);

            AuthenticationCredentials auth = new AuthenticationCredentials
            {
                Username = User.Username,
                Password = password,
                ClientVersion = PoroServer.ClientVersion,
                IpAddress = "209.133.52.232",
                Locale = Shard.Locale,
                Domain = "lolclient.lol.riotgames.com",
                AuthToken = GetAuthKey(User.Username, password, Shard.LoginQueue)
            };

            Session login = await Login(_client, auth);

            _accountId = login.Summary.AccountId;

            await _client.SubscribeAsync("my-rtmps", "messagingDestination", "bc", "bc-" + login.Summary.AccountId.ToString());
            await _client.SubscribeAsync("my-rtmps", "messagingDestination", "gn-" + login.Summary.AccountId.ToString(), "gn-" + login.Summary.AccountId.ToString());
            await _client.SubscribeAsync("my-rtmps", "messagingDestination", "cn-" + login.Summary.AccountId.ToString(), "cn-" + login.Summary.AccountId.ToString());
            bool LoggedIn = await _client.LoginAsync(User.Username.ToLower(), login.Token);

            //TODO: Find easier way of getting summoner name and id without having to download a huge packet
            LoginDataPacket dataPacket = await GetLoginPacket(_client);
            _summonerId = dataPacket.AllSummonerData.Summoner.SumId;
            _summonerName = dataPacket.AllSummonerData.Summoner.Name;

            return LoggedIn;
        }

        public static Task<LoginDataPacket> GetLoginPacket(RtmpClient client)
        {
            return InvokeAsync<LoginDataPacket>(client, "clientFacadeService", "getLoginDataPacketForUser");
        }

        private static Task<Session> Login(RtmpClient client, AuthenticationCredentials auth)
        {
            return InvokeAsync<Session>(client, "loginService", "login", auth);
        }

        private static Task<T> InvokeAsync<T>(RtmpClient client, string destination, string method, params object[] argument)
        {
            return client.InvokeAsync<T>("my-rtmps", destination, method, argument);
        }

        private static string GetAuthKey(String Username, String Password, String LoginQueue)
        {
            string payload = string.Format("user={0},password={1}", Username, Password);
            string query = string.Format("payload={0}", payload);
            string URL = string.Format("{0}login-queue/rest/queue/authenticate", LoginQueue);

            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = client.UploadString(URL, query);

                Dictionary<string, object> deserializedJSON = JsonConvert.DeserializeObject<Dictionary<string, object>>(HtmlResult);

                return (string)deserializedJSON["token"];
            }
        }

        public Task<T> Forward<T>(string destination, string method, params object[] argument)
        {
            return _client.InvokeAsync<T>("my-rtmps", destination, method, argument);
        }

        public async Task<object> ForwardCommand(object sender, CommandMessageReceivedEventArgs e)
        {
            object s = await _client.InvokeAsync<string>(null, e.Message);
            if (s != null && s.GetType() == typeof(string))
            {
                return (string)s == "success";
            }
            else
            {
                return s;
            }
        }
    }
}
