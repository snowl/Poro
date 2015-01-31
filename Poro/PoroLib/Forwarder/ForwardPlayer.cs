using PoroLib.Forwarder.Shards;
using RtmpSharp.IO;
using RtmpSharp.Messaging;
using RtmpSharp.Messaging.Messages;
using RtmpSharp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoroLib.Forwarder
{
    public class ForwardPlayer
    {
        protected RtmpClient _client;
        protected int _accountId;
        protected int _summonerId;
        protected string _summonerName;

        public ForwardPlayer(BaseShard Shard, SerializationContext Context)
        {
            _client = new RtmpClient(new Uri("rtmps://" + Shard.URL + ":2099"), Context, ObjectEncoding.Amf3);
            //_client.MessageReceived += Client_MessageReceived;
            //_client.CallbackException += Client_CallbackException;
            Connect();
        }

        public async void Connect()
        {
            await _client.ConnectAsync();
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
