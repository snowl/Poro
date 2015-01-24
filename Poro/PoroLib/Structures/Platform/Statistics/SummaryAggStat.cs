﻿using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.statistics.SummaryAggStat")]
    public class SummaryAggStat
    {
        [SerializedName("statType")]
        public String StatType { get; set; }

        [SerializedName("count")]
        public Double Count { get; set; }

        [SerializedName("value")]
        public Double Value { get; set; }
    }
}
