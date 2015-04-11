using PoroLib.Structures;
using RtmpSharp.IO.AMF3;
using RtmpSharp.Messaging;

namespace PoroLib.Messages.LeaguesServiceProxy
{
    class GetMyLeaguePositions : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            e.ReturnRequired = true;
            e.Data = new SummonerLeagueItemsDTO()
                         {
                             summonerLeagues = new ArrayCollection()
                         };

            return e;
        }
    }
}
