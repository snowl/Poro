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

            object result;

            object[] testConvert = e.OriginalMessage.Body as object[];

            if (testConvert.Length != 0)
            {
                result = await _client.Forward<object>(e.Destination, e.Operation, testConvert);
            }
            else
            {
                result = await _client.Forward<object>(e.Destination, e.Operation);
            }

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
