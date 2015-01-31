using PoroLib.Structures;
using RtmpSharp.Messaging;

namespace PoroLib.Messages.InventoryService
{
    //Not a typo
    class GetSumonerActiveBoosts : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            SummonerActiveBoostsDTO activeBoosts = new SummonerActiveBoostsDTO
            {
                IPBoostEndDate = 0.0,
                XPBoostEndDate = 0.0,
                IPBoostPerWinCount = 0,
                IPLoyaltyBoost = 0,
                SummonerID = 1,
                XPBoostPerWinCount = 0,
                XPLoyaltyBoost = 0
            };

            e.ReturnRequired = true;
            e.Data = activeBoosts;

            return e;
        }
    }
}
