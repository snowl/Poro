using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.runes.SummonerRune")]
    public class SummonerRune
    {
        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }

        [SerializedName("quantity")]
        public Int32 Quantity { get; set; }

        [SerializedName("runeId")]
        public Int32 RuneId { get; set; }

        [SerializedName("purchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [SerializedName("purchased")]
        public DateTime Purchased { get; set; }
    }
}
