﻿using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.SummonerDefaultSpells")]
    public class SummonerDefaultSpells
    {
        [SerializedName("summonerDefaultSpellsJson")]
        public object SummonerDefaultSpellsJson { get; set; }
        [SerializedName("summonerDefaultSpellMap")]
        public object SummonerDefaultSpellMap { get; set; }
        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }
    }
}
