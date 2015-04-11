using PoroLib.Messages;
using RtmpSharp.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PoroLib.Messages
{
    public class MessageHandler
    {
        private Dictionary<string, List<IMessage>> _messageHandlers;

        /// <summary>
        /// Creates a new message handler class
        /// </summary>
        public MessageHandler()
        {
            _messageHandlers = new Dictionary<string, List<IMessage>>();
        }

        /// <summary>
        /// Registers a destination & all the handlers in the destination
        /// </summary>
        /// <param name="Destination"></param>
        public void Register(string Destination)
        {
            //Gets all the handlers that are under the destination namespace
            var structures = Assembly.GetExecutingAssembly().GetTypes().Where(x => String.Equals(x.Namespace, string.Format("PoroLib.Messages.{0}", Destination), StringComparison.Ordinal));

            //Creates a new instance of each handler and add them to the dictionary
            List<IMessage> handlerList = new List<IMessage>();
            foreach (Type ObjectType in structures)
            {
                if (ObjectType.GetInterfaces().Contains(typeof(IMessage)))
                {
                    IMessage messageInterface = (IMessage)Activator.CreateInstance(ObjectType);
                    handlerList.Add(messageInterface);
                }
            }

            if (handlerList.Count == 0)
                throw new Exception("Destination has no handler functions.");

            _messageHandlers.Add(Destination.ToLower(), handlerList);
        }

        /// <summary>
        /// Handles a message request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The message to handle</param>
        /// <returns>The handled message</returns>
        public RemotingMessageReceivedEventArgs Handle(object sender, RemotingMessageReceivedEventArgs e)
        {
            if (!_messageHandlers.ContainsKey(e.Destination.ToLower()))
                return null;

            List<IMessage> handlers = _messageHandlers[e.Destination.ToLower()];

            foreach (IMessage handler in handlers)
            {
                string handleName = handler.GetType().Name;
                if (e.Operation.ToLower() == handleName.ToLower())
                {
                    return handler.HandleMessage(sender, e);
                }
            }
            
            return null;
        }
    }
}
