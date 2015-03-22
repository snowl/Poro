﻿using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using System;
using System.Collections.Generic;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.statistics.SummaryAggStats")]
    public class SummaryAggStats
    {
        [SerializedName("statsJson")]
        public object StatsJson { get; set; }

        [SerializedName("stats")]
        public ArrayCollection Stats { get; set; }
    }
}
