﻿using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.kudos.dto.PendingKudosDTO")]
    public class PendingKudosDTO
    {
        [SerializedName("pendingCounts")]
        public ArrayCollection PendingCounts { get; set; }
    }
}
