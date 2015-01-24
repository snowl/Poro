﻿using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.catalog.runes.RuneType")]
    public class RuneType
    {
        [SerializedName("runeTypeId")]
        public Int32 Id { get; set; }
        [SerializedName("name")]
        public String Name { get; set; }
    }
}
