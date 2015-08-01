using PoroLib.Forwarder.Shards;
using RtmpSharp.IO;
using RtmpSharp.Messaging;
using RtmpSharp.Net;
using System.Threading.Tasks;

namespace PoroLib.Forwarder
{
    public class MessageForwarder
    {
        internal ForwardPlayer _client;
        private SerializationContext _context;
        
        /// <summary>
        /// Returns if the MessageForwarder is forwarding messages
        /// </summary>
        public bool Forwarding { get { return _client != null; } }

        /// <summary>
        /// Creates a new  message forwarder with the specified context
        /// </summary>
        /// <param name="context">The serialization context</param>
        public MessageForwarder(SerializationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Assigns a forward player to the message forwarder
        /// </summary>
        /// <param name="client"></param>
        public void Assign(ForwardPlayer client)
        {
            _client = client;
        }

        /// <summary>
        /// Forwards a message request to the forward player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The message to forward</param>
        /// <returns></returns>
        public async Task<RemotingMessageReceivedEventArgs> Handle(object sender, RemotingMessageReceivedEventArgs e)
        {
            if (_client == null)
                throw new NotConnectedException();

            object[] data = e.OriginalMessage.Body as object[];

            //If the client tries to send data, switch the acct id and sum id to what is currently logged in
            /*for (int i = 0; i < data.Length; i++)
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
            }*/

            object result;

            if (data.Length != 0)
            {
                result = await _client.Forward<object>(e.Destination, e.Operation, data);
            }
            else
            {
                result = await _client.Forward<object>(e.Destination, e.Operation);
            }

            //Do we need to change it back? Who knows! Seems to work at the moment

            e.Data = result;
            e.ReturnRequired = true;

            return e;
        }

        /// <summary>
        /// Forwards a command. Currently not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The command to forward</param>
        /// <returns></returns>
        public async Task<object> HandleCommand(object sender, CommandMessageReceivedEventArgs e)
        {
            if (_client == null)
                throw new NotConnectedException();

            return await _client.ForwardCommand(sender, e);
        }
    }
}
