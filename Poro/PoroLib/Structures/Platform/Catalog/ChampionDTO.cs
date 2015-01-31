﻿using RtmpSharp.IO;
using System;
using System.Collections.Generic;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.catalog.champion.ChampionDTO")]
    public class ChampionDTO
    {
        [SerializedName("owned")]
        public Boolean Owned { get; set; }

        [SerializedName("freeToPlayReward")]
        public Boolean FreeToPlayReward { get; set; }

        [SerializedName("championId")]
        public Int32 ChampionID { get; set; }

        [SerializedName("freeToPlay")]
        public Boolean FreeToPlay { get; set; }

        [SerializedName("endDate")]
        public Double EndDate { get; set; }

        [SerializedName("active")]
        public Boolean Active { get; set; }

        [SerializedName("botEnabled")]
        public Boolean BotEnabled { get; set; }

        [SerializedName("winCountRemaining")]
        public Int32 WinCountRemaining { get; set; }

        [SerializedName("purchaseDate")]
        public Double PurchaseDate { get; set; }

        [SerializedName("rankedPlayEnabled")]
        public Boolean RankedPlayEnabled { get; set; }

        [SerializedName("purchased")]
        public Double PurchaseDateTime { get; set; }

        [SerializedName("championSkins")]
        public List<ChampionSkinDTO> ChampionSkins { get; set; }
    }
}
