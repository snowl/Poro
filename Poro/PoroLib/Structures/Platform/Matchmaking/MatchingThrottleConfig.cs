﻿using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using System;
using System.Collections.Generic;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.matchmaking.MatchingThrottleConfig")]
    public class MatchingThrottleConfig
    {
        [SerializedName("limit")]
        public Double Limit { get; set; }

        [SerializedName("matchingThrottleProperties")]
        public ArrayCollection MatchingThrottleProperties { get; set; }

        [SerializedName("cacheName")]
        public String CacheName { get; set; }
    }
}
