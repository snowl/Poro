﻿using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.boost.SummonerActiveBoostsDTO")]
    public class SummonerActiveBoostsDTO
    {
        [SerializedName("xpBoostEndDate")]
        public Double XPBoostEndDate { get; set; }

        [SerializedName("xpBoostPerWinCount")]
        public Int32 XPBoostPerWinCount { get; set; }

        [SerializedName("xpLoyaltyBoost")]
        public Int32 XPLoyaltyBoost { get; set; }

        [SerializedName("ipBoostPerWinCount")]
        public Int32 IPBoostPerWinCount { get; set; }

        [SerializedName("ipLoyaltyBoost")]
        public Int32 IPLoyaltyBoost { get; set; }

        [SerializedName("summonerId")]
        public Int32 SummonerID { get; set; }

        [SerializedName("ipBoostEndDate")]
        public Double IPBoostEndDate { get; set; }
    }
}
