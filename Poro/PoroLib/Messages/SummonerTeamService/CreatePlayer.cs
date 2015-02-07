using RtmpSharp.Messaging;

namespace PoroLib.Messages.SummonerTeamService
{
    class CreatePlayer : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            e.ReturnRequired = true;
            e.Data = null;

            return e;
        }
    }
}
