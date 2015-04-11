﻿using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.leagues.client.dto.SummonerLeagueItemsDTO")]
    public class SummonerLeagueItemsDTO
    {
        [SerializedName("summonerLeagues")]
        public ArrayCollection summonerLeagues { get; set; }
    }
}
