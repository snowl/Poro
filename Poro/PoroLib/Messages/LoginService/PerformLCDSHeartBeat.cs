using PoroLib.Structures;
using RtmpSharp.Messaging;

namespace PoroLib.Messages.LoginService
{
    class PerformLCDSHeartBeat : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            e.ReturnRequired = true;
            e.Data = "5";

            return e;
        }
    }
}
