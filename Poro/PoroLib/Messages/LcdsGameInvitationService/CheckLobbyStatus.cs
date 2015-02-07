using RtmpSharp.Messaging;

namespace PoroLib.Messages.LcdsGameInvitationService
{
    class CheckLobbyStatus : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            e.ReturnRequired = true;
            e.Data = null;

            return e;
        }
    }
}
