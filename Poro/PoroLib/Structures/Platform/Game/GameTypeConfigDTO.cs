﻿using RtmpSharp.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.game.GameTypeConfigDTO")]
    public class GameTypeConfigDTO
    {
        [SerializedName("id")]
        public Int32 Id { get; set; }
        [SerializedName("allowTrades")]
        public Boolean AllowTrades { get; set; }
        [SerializedName("name")]
        public String Name { get; set; }
        [SerializedName("mainPickTimerDuration")]
        public Int32 MainPickTimerDuration { get; set; }
        [SerializedName("exclusivePick")]
        public Boolean ExclusivePick { get; set; }
        [SerializedName("duplicatePick")]
        public Boolean DuplicatePick { get; set; }
        [SerializedName("crossTeamChampionPool")]
        public Boolean CrossTeamChampionPool { get; set; }
        [SerializedName("teamChampionPool")]
        public Boolean TeamChampionPool { get; set; }
        [SerializedName("pickMode")]
        public String PickMode { get; set; }
        [SerializedName("maxAllowableBans")]
        public Int32 MaxAllowableBans { get; set; }
        [SerializedName("banTimerDuration")]
        public Int32 BanTimerDuration { get; set; }
        [SerializedName("postPickTimerDuration")]
        public Int32 PostPickTimerDuration { get; set; }
    }
}
