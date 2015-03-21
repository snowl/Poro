using PoroLib.Forwarder.Shards;
using RtmpSharp.IO;
using RtmpSharp.Messaging;
using RtmpSharp.Net;
using System.Threading.Tasks;

namespace PoroLib.Forwarder
{
    public class MessageForwarder
    {
        private ForwardPlayer _client;
        private SerializationContext _context;
        public bool Forwarding { get { return _client != null; } }

        public MessageForwarder(SerializationContext context)
        {
            _context = context;
        }

        public void Assign(ForwardPlayer client)
        {
            _client = client;
        }

        public async Task<RemotingMessageReceivedEventArgs> Handle(object sender, RemotingMessageReceivedEventArgs e)
        {
            if (_client == null)
                throw new NotConnectedException();

            object[] data = e.OriginalMessage.Body as object[];

            //If the client tries to send data, switch the acct id and sum id to what is currently logged in
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] is double)
                {
                    double conv = (double)data[i];
                    if (conv == int.MaxValue - 1)
                    {
                        //int.MaxValue - 1 = sumId
                        data[i] = _client._summonerId;
                    }
                    else if (conv == int.MaxValue - 2)
                    {
                        //int.MaxValue - 2 = accId
                        data[i] = _client._accountId;
                    }
                }
            }

            object result;

            if (data.Length != 0)
            {
                result = await _client.Forward<object>(e.Destination, e.Operation, data);
            }
            else
            {
                result = await _client.Forward<object>(e.Destination, e.Operation);
            }

            //Do we need to change it back? Who knows!

            e.Data = result;
            e.ReturnRequired = true;

            return e;
        }

        public async Task<object> HandleCommand(object sender, CommandMessageReceivedEventArgs e)
        {
            if (_client == null)
                throw new NotConnectedException();

            return await _client.ForwardCommand(sender, e);
        }
    }
}
