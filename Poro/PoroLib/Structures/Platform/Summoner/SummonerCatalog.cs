using RtmpSharp.IO;
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
        public FluorineFx.AMF3.ArrayCollection TalentTree { get; set; } 
        //public List<TalentGroup> TalentTree { get; set; }
        [SerializedName("spellBookConfig")]
        public List<RuneSlot> SpellBookConfig { get; set; }
    }
}
