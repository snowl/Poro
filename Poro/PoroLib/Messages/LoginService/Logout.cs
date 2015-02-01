using PoroLib.Structures;
using RtmpSharp.Messaging;

namespace PoroLib.Messages.LoginService
{
    class Logout : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            e.ReturnRequired = true;
            e.Data = null;

            return e;
        }
    }
}
