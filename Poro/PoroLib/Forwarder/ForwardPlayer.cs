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
        internal User _user;
        internal BaseShard _shard;
        internal double _accountId;
        internal double _summonerId;
        internal string _summonerName;
        internal LoginDataPacket _packet;

        /// <summary>
        /// Creates a new player to forward packets through
        /// </summary>
        /// <param name="User">The user data to login with</param>
        /// <param name="Shard">The shard to login with</param>
        /// <param name="Context">The serialization context</param>
        public ForwardPlayer(User User, BaseShard Shard, SerializationContext Context)
        {
            _user = User;
            _shard = Shard;
            _client = new RtmpClient(new Uri("rtmps://" + Shard.URL + ":2099"), Context, ObjectEncoding.Amf3);
            //_client.MessageReceived += Client_MessageReceived;
            //_client.CallbackException += Client_CallbackException;
        }

        /// <summary>
        /// Connects to the 
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Shard"></param>
        /// <returns></returns>
        public async Task<bool> Connect()
        {
            //Connects to the RTMPS client
            await _client.ConnectAsync();

            //Decrypts the users password when logging in
            string password = DPAPI.Decrypt(_user.Password);

            AuthenticationCredentials auth = new AuthenticationCredentials
            {
                Username = _user.Username,
                Password = password,
                ClientVersion = PoroServer.ClientVersion,
                IpAddress = "209.133.52.232",
                Locale = _shard.Locale,
                Domain = "lolclient.lol.riotgames.com",
                AuthToken = GetAuthKey(_user.Username, password, _shard.LoginQueue)
            };

            //Gets the current login session
            Session login = await Login(_client, auth);

            _accountId = login.Summary.AccountId;

            //Subscribes to server messages
            await _client.SubscribeAsync("my-rtmps", "messagingDestination", "bc", "bc-" + login.Summary.AccountId.ToString());
            await _client.SubscribeAsync("my-rtmps", "messagingDestination", "gn-" + login.Summary.AccountId.ToString(), "gn-" + login.Summary.AccountId.ToString());
            await _client.SubscribeAsync("my-rtmps", "messagingDestination", "cn-" + login.Summary.AccountId.ToString(), "cn-" + login.Summary.AccountId.ToString());
            bool LoggedIn = await _client.LoginAsync(_user.Username.ToLower(), login.Token);

            //TODO: Find easier way of getting summoner name and id without having to download a huge packet
            LoginDataPacket dataPacket = await GetLoginPacket(_client);
            _packet = dataPacket;
            _summonerId = dataPacket.AllSummonerData.Summoner.SumId;
            _summonerName = dataPacket.AllSummonerData.Summoner.Name;

            return LoggedIn;
        }

        /// <summary>
        /// Gets the login packet for the user
        /// </summary>
        /// <param name="client">The server to get the packet through</param>
        /// <returns>A LoginDataPacket</returns>
        public static Task<LoginDataPacket> GetLoginPacket(RtmpClient client)
        {
            return InvokeAsync<LoginDataPacket>(client, "clientFacadeService", "getLoginDataPacketForUser");
        }

        /// <summary>
        /// Logs the user into the RTMPS server
        /// </summary>
        /// <param name="client">The server to log the player into</param>
        /// <param name="auth">The authentication details for the user</param>
        /// <returns>A session object</returns>
        private static Task<Session> Login(RtmpClient client, AuthenticationCredentials auth)
        {
            return InvokeAsync<Session>(client, "loginService", "login", auth);
        }

        /// <summary>
        /// Invokes a call into the server
        /// </summary>
        /// <typeparam name="T">The type of object to return</typeparam>
        /// <param name="client">The server to pass the data to</param>
        /// <param name="destination">The RPC destination</param>
        /// <param name="method">The RPC method</param>
        /// <param name="argument">The data to pass through to the method</param>
        /// <returns>Returns the object</returns>
        private static Task<T> InvokeAsync<T>(RtmpClient client, string destination, string method, params object[] argument)
        {
            return client.InvokeAsync<T>("my-rtmps", destination, method, argument);
        }

        /// <summary>
        /// Gets the authorization key of the user
        /// </summary>
        /// <param name="Username">The username of the player</param>
        /// <param name="Password">The password of the player</param>
        /// <param name="LoginQueue">The url of the login queue</param>
        /// <returns>Returns the authorization key for the player</returns>
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

                //Deserializes the json and gets the token field
                return (string)deserializedJSON["token"];
            }
        }

        /// <summary>
        /// Forwards a request to the connected server
        /// </summary>
        /// <typeparam name="T">The type that will be returned</typeparam>
        /// <param name="destination">The RPC destination</param>
        /// <param name="method">The RPC method</param>
        /// <param name="argument">The data to pass through to the method</param>
        /// <returns>The data returned from the server</returns>
        public Task<T> Forward<T>(string destination, string method, params object[] argument)
        {
            return _client.InvokeAsync<T>("my-rtmps", destination, method, argument);
        }

        /// <summary>
        /// Forwards a server command to the server. Currently not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The command to send to the server</param>
        /// <returns>The result reutrned</returns>
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
