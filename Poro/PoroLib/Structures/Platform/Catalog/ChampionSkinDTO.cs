﻿using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.catalog.champion.ChampionSkinDTO")]
    public class ChampionSkinDTO
    {
        [SerializedName("owned")]
        public Boolean Owned { get; set; }

        [SerializedName("skinId")]
        public Int32 SkinID { get; set; }

        [SerializedName("freeToPlayReward")]
        public Boolean FreeToPlayReward { get; set; }

        [SerializedName("championId")]
        public Int32 ChampionID { get; set; }

        [SerializedName("endDate")]
        public Double EndDate { get; set; }

        [SerializedName("winCountRemaining")]
        public Int32 WinCountRemaining { get; set; }

        [SerializedName("purchaseDate")]
        public Double PurchaseDate { get; set; }

        [SerializedName("stillObtainable")]
        public Boolean StillObtainable { get; set; }

        [SerializedName("lastSelected")]
        public Boolean LastSelected { get; set; }
    }
}
