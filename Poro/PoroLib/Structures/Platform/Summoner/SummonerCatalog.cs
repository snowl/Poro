using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using System;
using System.Collections.Generic;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.SummonerCatalog")]
    public class SummonerCatalog
    {
        [SerializedName("items")]
        public object Items { get; set; }
        [SerializedName("talentTree")]
        public ArrayCollection TalentTree { get; set; }
        [SerializedName("spellBookConfig")]
        public ArrayCollection SpellBookConfig { get; set; }
    }
}
