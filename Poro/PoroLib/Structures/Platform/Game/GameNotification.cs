﻿using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.game.message.GameNotification")]
    public class GameNotification
    {
        [SerializedName("messageCode")]
        public string MessageCode { get; set; }
        [SerializedName("messageArgument")]
        public object MessageArgument { get; set; }
        [SerializedName("type")]
        public string Type { get; set; }
    }
}
