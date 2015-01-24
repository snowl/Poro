using RtmpSharp.Messaging;

namespace PoroLib.Messages
{
    interface IMessage
    {
        RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e);
    }
}
