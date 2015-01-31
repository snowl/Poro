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

        public MessageForwarder(SerializationContext context)
        {
            _context = context;
            _client = new ForwardPlayer(new OCE(), context);
        }

        public void Assign(ForwardPlayer client)
        {
            _client = client;
        }

        public async Task<RemotingMessageReceivedEventArgs> Handle(object sender, RemotingMessageReceivedEventArgs e)
        {
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
            return await _client.ForwardCommand(sender, e);
        }
    }
}
