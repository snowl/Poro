using PoroLib.Structures;
using RtmpSharp.Messaging;
using System.Collections.Generic;

namespace PoroLib.Messages.SummonerRuneService
{
    class GetSummonerRuneInventory : IMessage
    { 
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            SummonerRuneInventory inventory = new SummonerRuneInventory
            {
                DateString = "Thu Jun 27 20:58:33 PDT 2013",
                SummonerId = int.MaxValue - 1,
                SummonerRunes = new List<SummonerRune>()
            };

            e.ReturnRequired = true;
            e.Data = inventory;

            return e;
        }
    }
}
