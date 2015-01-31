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

        public MessageHandler()
        {
            _messageHandlers = new Dictionary<string, List<IMessage>>();
        }

        public void Register(string Destination)
        {
            var structures = Assembly.GetExecutingAssembly().GetTypes().Where(x => String.Equals(x.Namespace, string.Format("PoroLib.Messages.{0}", Destination), StringComparison.Ordinal));

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
