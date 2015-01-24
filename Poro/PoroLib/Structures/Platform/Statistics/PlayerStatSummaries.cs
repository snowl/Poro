﻿using RtmpSharp.IO;
using System;
using System.Collections.Generic;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.statistics.PlayerStatSummaries")]
    public class PlayerStatSummaries
    {
        [SerializedName("season")]
        public Int32 Season { get; set; }
        [SerializedName("userId")]
        public Int32 UserID { get; set; }
        [SerializedName("playerStatSummarySet")]
        public List<PlayerStatSummary> SummaryList { get; set; }
    }
}
