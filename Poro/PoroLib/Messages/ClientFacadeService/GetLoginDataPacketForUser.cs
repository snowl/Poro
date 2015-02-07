using PoroLib.Structures;
using RtmpSharp.IO;
using RtmpSharp.Messaging;
using System;
using System.Collections.Generic;

namespace PoroLib.Messages.ClientFacadeService
{
    class GetLoginDataPacketForUser : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            LoginDataPacket packet = new LoginDataPacket
            {
                RestrictedGamesRemainingForRanked = -1,
                PlayerStatSummaries = new PlayerStatSummaries
                {
                    UserID = 1,
                    Season = 4,
                    SummaryList = new List<PlayerStatSummary>
                            {
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "AramUnranked2x2",
                                    TypeString = "AramUnranked2x2",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "CAP1x1",
                                    TypeString = "CAP1x1",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "AramUnranked6x6",
                                    TypeString = "AramUnranked6x6",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "CAP5x5",
                                    TypeString = "CAP5x5",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "OdinUnranked",
                                    TypeString = "OdinUnranked",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "AramUnranked1x1",
                                    TypeString = "AramUnranked1x1",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "Unranked3x3",
                                    TypeString = "Unranked3x3",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "AramUnranked5x5",
                                    TypeString = "AramUnranked5x5",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                },
                                new PlayerStatSummary
                                {
                                    Leaves = 0,
                                    Wins = 0,
                                    Rating = 400,
                                    UserId = 1,
                                    Losses = 0,
                                    ModifyDate = DateTime.Now,
                                    MaxRating = 0,
                                    Type = "AramUnranked3x3",
                                    TypeString = "AramUnranked3x3",
                                    AggregatedStats = new SummaryAggStats { Stats = new List<SummaryAggStat> { } }
                                }
                            }
                },
                RestrictedChatGamesRemaining = -1,
                MinutesUntilShutdown = -1,
                Minor = false,
                MaxPracticeGameSize = 5,
                SummonerCatalog = new SummonerCatalog
                {
                    Items = null,
                    TalentTree = new List<TalentGroup>
                            {
                                new TalentGroup 
                                {
                                    Index = 0,
                                    Name = "Offense",
                                    TltGroupId = 1,
                                    TalentRows = new List<TalentRow>
                                    {
                                        new TalentRow
                                        {
                                            Index = 3,
                                            TltGroupId = 1,
                                            PointsToActivate = 12,
                                            TltRowId = 4,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Warlord",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Warlord",
                                                    TltId = 4142,
                                                    Level3Desc = "Warlord",
                                                    TalentGroupId = 1,
                                                    GameCode = 4142,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Warlord",
                                                    TalentRowId = 4,
                                                    Level1Desc = "Warlord",
                                                    Name = "Warlord"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Archmage",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Archmage",
                                                    TltId = 4143,
                                                    Level3Desc = "Archmage",
                                                    TalentGroupId = 1,
                                                    GameCode = 4143,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Archmage",
                                                    TalentRowId = 4,
                                                    Level1Desc = "Archmage",
                                                    Name = "Archmage"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Dangerous Game",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Dangerous Game",
                                                    TltId = 4144,
                                                    Level3Desc = "Dangerous Game",
                                                    TalentGroupId = 1,
                                                    GameCode = 4144,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4134,
                                                    Level2Desc = "Dangerous Game",
                                                    TalentRowId = 4,
                                                    Level1Desc = "Dangerous Game",
                                                    Name = "Dangerous Game"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Blade Weaving",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Blade Weaving",
                                                    TltId = 4141,
                                                    Level3Desc = "Blade Weaving",
                                                    TalentGroupId = 1,
                                                    GameCode = 4141,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4131,
                                                    Level2Desc = "Blade Weaving",
                                                    TalentRowId = 4,
                                                    Level1Desc = "Blade Weaving",
                                                    Name = "Blade Weaving"
                                                }
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 4,
                                            TltRowId = 5,
                                            TltGroupId = 1,
                                            PointsToActivate = 16,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Frenzy",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Frenzy",
                                                    TltId = 4151,
                                                    Level3Desc = "Frenzy",
                                                    TalentGroupId = 1,
                                                    GameCode = 4151,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Frenzy",
                                                    TalentRowId = 5,
                                                    Level1Desc = "Frenzy",
                                                    Name = "Frenzy"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Devastating Strikes",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Devastating Strikes",
                                                    TltId = 4152,
                                                    Level3Desc = "Devastating Strikes",
                                                    TalentGroupId = 1,
                                                    GameCode = 4152,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Devastating Strikes",
                                                    TalentRowId = 5,
                                                    Level1Desc = "Devastating Strikes",
                                                    Name = "Devastating Strikes"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Arcane Blade",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Arcane Blade",
                                                    TltId = 4154,
                                                    Level3Desc = "Arcane Blade",
                                                    TalentGroupId = 1,
                                                    GameCode = 4154,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Arcane Blade",
                                                    TalentRowId = 5,
                                                    Level1Desc = "Arcane Blade",
                                                    Name = "Arcane Blade"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 2,
                                            TltGroupId = 1,
                                            PointsToActivate = 8,
                                            TltRowId = 3,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Arcane Mastery",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Arcane Mastery",
                                                    TltId = 4133,
                                                    Level3Desc = "Arcane Mastery",
                                                    TalentGroupId = 1,
                                                    GameCode = 4133,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4123,
                                                    Level2Desc = "Arcane Mastery",
                                                    TalentRowId = 3,
                                                    Level1Desc = "Arcane Mastery",
                                                    Name = "Arcane Mastery"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Martial Mastery",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Martial Mastery",
                                                    TltId = 4132,
                                                    Level3Desc = "Martial Mastery",
                                                    TalentGroupId = 1,
                                                    GameCode = 4132,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4122,
                                                    Level2Desc = "Martial Mastery",
                                                    TalentRowId = 3,
                                                    Level1Desc = "Martial Mastery",
                                                    Name = "Martial Mastery"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Spell Weaving",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Spell Weaving",
                                                    TltId = 4131,
                                                    Level3Desc = "Spell Weaving",
                                                    TalentGroupId = 1,
                                                    GameCode = 4131,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Spell Weaving",
                                                    TalentRowId = 3,
                                                    Level1Desc = "Spell Weaving",
                                                    Name = "Spell Weaving"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Executioner",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Executioner",
                                                    TltId = 4134,
                                                    Level3Desc = "Executioner",
                                                    TalentGroupId = 1,
                                                    GameCode = 4134,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Executioner",
                                                    TalentRowId = 3,
                                                    Level1Desc = "Executioner",
                                                    Name = "Executioner"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 5,
                                            TltRowId = 6,
                                            TltGroupId = 1,
                                            PointsToActivate = 20,                                            
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Havoc",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Havoc",
                                                    TltId = 4162,
                                                    Level3Desc = "Havoc",
                                                    TalentGroupId = 1,
                                                    GameCode = 4162,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Havoc",
                                                    TalentRowId = 6,
                                                    Level1Desc = "Havoc",
                                                    Name = "Havoc"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 0,
                                            TltGroupId = 1,
                                            TltRowId = 1,
                                            PointsToActivate = 0,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Fury",
                                                    MinLevel = 1,
                                                    MaxRank = 4,
                                                    Level4Desc = "Fury",
                                                    TltId = 4112,
                                                    Level3Desc = "Fury",
                                                    TalentGroupId = 1,
                                                    GameCode = 4112,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Fury",
                                                    TalentRowId = 1,
                                                    Level1Desc = "Fury",
                                                    Name = "Fury"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Sorcery",
                                                    MinLevel = 1,
                                                    MaxRank = 4,
                                                    Level4Desc = "Sorcery",
                                                    TltId = 4113,
                                                    Level3Desc = "Sorcery",
                                                    TalentGroupId = 1,
                                                    GameCode = 4113,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Sorcery",
                                                    TalentRowId = 1,
                                                    Level1Desc = "Sorcery",
                                                    Name = "Sorcery"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Butcher",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Butcher",
                                                    TltId = 4114,
                                                    Level3Desc = "Butcher",
                                                    TalentGroupId = 1,
                                                    GameCode = 4114,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Butcher",
                                                    TalentRowId = 1,
                                                    Level1Desc = "Butcher",
                                                    Name = "Butcher"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Double-Edged Sword",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Double-Edged Sword",
                                                    TltId = 4111,
                                                    Level3Desc = "Double-Edged Sword",
                                                    TalentGroupId = 1,
                                                    GameCode = 4111,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Double-Edged Sword",
                                                    TalentRowId = 1,
                                                    Level1Desc = "Double-Edged Sword",
                                                    Name = "Double-Edged Sword"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 1,
                                            TltRowId = 2,
                                            TltGroupId = 1,
                                            PointsToActivate = 4,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Brute Force",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Brute Force",
                                                    TltId = 4122,
                                                    Level3Desc = "Brute Force",
                                                    TalentGroupId = 1,
                                                    GameCode = 4122,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Brute Force",
                                                    TalentRowId = 2,
                                                    Level1Desc = "Brute Force",
                                                    Name = "Brute Force"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Mental Force",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Mental Force",
                                                    TltId = 4123,
                                                    Level3Desc = "Mental Force",
                                                    TalentGroupId = 1,
                                                    GameCode = 4123,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Mental Force",
                                                    TalentRowId = 2,
                                                    Level1Desc = "Mental Force",
                                                    Name = "Mental Force"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Feast",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Feast",
                                                    TltId = 4124,
                                                    Level3Desc = "Feast",
                                                    TalentGroupId = 1,
                                                    GameCode = 4124,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4114,
                                                    Level2Desc = "Feast",
                                                    TalentRowId = 2,
                                                    Level1Desc = "Feast",
                                                    Name = "Feast"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Expose Weakness",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Expose Weakness",
                                                    TltId = 4121,
                                                    Level3Desc = "Expose Weakness",
                                                    TalentGroupId = 1,
                                                    GameCode = 4121,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Expose Weakness",
                                                    TalentRowId = 2,
                                                    Level1Desc = "Expose Weakness",
                                                    Name = "Expose Weakness"
                                                },
                                            }
                                        }
                                    }
                                },
                                new TalentGroup 
                                {
                                    Index = 1,
                                    Name = "Defense",
                                    TltGroupId = 2,
                                    TalentRows = new List<TalentRow>
                                    {
                                        new TalentRow
                                        {
                                            Index = 1,
                                            TltGroupId = 2,
                                            PointsToActivate = 4,
                                            TltRowId = 8,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Veteran's Scars",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Veteran's Scars",
                                                    TltId = 4222,
                                                    Level3Desc = "Veteran's Scars",
                                                    TalentGroupId = 2,
                                                    GameCode = 4222,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Veteran's Scars",
                                                    TalentRowId = 8,
                                                    Level1Desc = "Veteran's Scars",
                                                    Name = "Veteran's Scars"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Unyielding",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Unyielding",
                                                    TltId = 4221,
                                                    Level3Desc = "Unyielding",
                                                    TalentGroupId = 2,
                                                    GameCode = 4221,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4211,
                                                    Level2Desc = "Unyielding",
                                                    TalentRowId = 8,
                                                    Level1Desc = "Unyielding",
                                                    Name = "Unyielding"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Bladed Armor",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Bladed Armor",
                                                    TltId = 4224,
                                                    Level3Desc = "Bladed Armor",
                                                    TalentGroupId = 2,
                                                    GameCode = 4224,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4214,
                                                    Level2Desc = "Bladed Armor",
                                                    TalentRowId = 8,
                                                    Level1Desc = "Bladed Armor",
                                                    Name = "Bladed Armor"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 2,
                                            TltRowId = 9,
                                            TltGroupId = 2,
                                            PointsToActivate = 8,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Hardiness",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Hardiness",
                                                    TltId = 4233,
                                                    Level3Desc = "Hardiness",
                                                    TalentGroupId = 2,
                                                    GameCode = 4233,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Hardiness",
                                                    TalentRowId = 9,
                                                    Level1Desc = "Hardiness",
                                                    Name = "Hardiness"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Oppression",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Oppression",
                                                    TltId = 4231,
                                                    Level3Desc = "Oppression",
                                                    TalentGroupId = 2,
                                                    GameCode = 4231,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Oppression",
                                                    TalentRowId = 9,
                                                    Level1Desc = "Oppression",
                                                    Name = "Oppression"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Resistance",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Resistance",
                                                    TltId = 4234,
                                                    Level3Desc = "Resistance",
                                                    TalentGroupId = 2,
                                                    GameCode = 4234,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Resistance",
                                                    TalentRowId = 9,
                                                    Level1Desc = "Resistance",
                                                    Name = "Resistance"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Juggernaut",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Juggernaut",
                                                    TltId = 4232,
                                                    Level3Desc = "Juggernaut",
                                                    TalentGroupId = 2,
                                                    GameCode = 4232,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4222,
                                                    Level2Desc = "Juggernaut",
                                                    TalentRowId = 9,
                                                    Level1Desc = "Juggernaut",
                                                    Name = "Juggernaut"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 5,
                                            TltGroupId = 2,
                                            TltRowId = 12,
                                            PointsToActivate = 20,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Tenacious",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Tenacious",
                                                    TltId = 4262,
                                                    Level3Desc = "Tenacious",
                                                    TalentGroupId = 2,
                                                    GameCode = 4262,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Tenacious",
                                                    TalentRowId = 12,
                                                    Level1Desc = "Tenacious",
                                                    Name = "Tenacious"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 0,
                                            TltRowId = 7,
                                            TltGroupId = 2,
                                            PointsToActivate = 0,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Tough Skin",
                                                    MinLevel = 1,
                                                    MaxRank = 2,
                                                    Level4Desc = "Tough Skin",
                                                    TltId = 4214,
                                                    Level3Desc = "Tough Skin",
                                                    TalentGroupId = 2,
                                                    GameCode = 4214,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Tough Skin",
                                                    TalentRowId = 7,
                                                    Level1Desc = "Tough Skin",
                                                    Name = "Tough Skin"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Recovery",
                                                    MinLevel = 1,
                                                    MaxRank = 2,
                                                    Level4Desc = "Recovery",
                                                    TltId = 4212,
                                                    Level3Desc = "Recovery",
                                                    TalentGroupId = 2,
                                                    GameCode = 4212,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Recovery",
                                                    TalentRowId = 7,
                                                    Level1Desc = "Recovery",
                                                    Name = "Recovery"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Block",
                                                    MinLevel = 1,
                                                    MaxRank = 2,
                                                    Level4Desc = "Block",
                                                    TltId = 4211,
                                                    Level3Desc = "Block",
                                                    TalentGroupId = 2,
                                                    GameCode = 4211,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Block",
                                                    TalentRowId = 7,
                                                    Level1Desc = "Block",
                                                    Name = "Block"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Enchanted Armor",
                                                    MinLevel = 1,
                                                    MaxRank = 2,
                                                    Level4Desc = "Enchanted Armor",
                                                    TltId = 4213,
                                                    Level3Desc = "Enchanted Armor",
                                                    TalentGroupId = 2,
                                                    GameCode = 4213,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Enchanted Armor",
                                                    TalentRowId = 7,
                                                    Level1Desc = "Enchanted Armor",
                                                    Name = "Enchanted Armor"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 3,
                                            TltGroupId = 2,
                                            PointsToActivate = 12,
                                            TltRowId = 10,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Reinforced Armor",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Reinforced Armor",
                                                    TltId = 4243,
                                                    Level3Desc = "Reinforced Armor",
                                                    TalentGroupId = 2,
                                                    GameCode = 4243,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4233,
                                                    Level2Desc = "Reinforced Armor",
                                                    TalentRowId = 10,
                                                    Level1Desc = "Reinforced Armor",
                                                    Name = "Reinforced Armor"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Perseverance",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Perseverance",
                                                    TltId = 4241,
                                                    Level3Desc = "Perseverance",
                                                    TalentGroupId = 2,
                                                    GameCode = 4241,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Perseverance",
                                                    TalentRowId = 10,
                                                    Level1Desc = "Perseverance",
                                                    Name = "Perseverance"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Swiftness",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Swiftness",
                                                    TltId = 4242,
                                                    Level3Desc = "Swiftness",
                                                    TalentGroupId = 2,
                                                    GameCode = 4242,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Swiftness",
                                                    TalentRowId = 10,
                                                    Level1Desc = "Swiftness",
                                                    Name = "Swiftness"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Evasive",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Evasive",
                                                    TltId = 4244,
                                                    Level3Desc = "Evasive",
                                                    TalentGroupId = 2,
                                                    GameCode = 4244,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4234,
                                                    Level2Desc = "Evasive",
                                                    TalentRowId = 10,
                                                    Level1Desc = "Evasive",
                                                    Name = "Evasive"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 4,
                                            TltRowId = 11,
                                            TltGroupId = 2,
                                            PointsToActivate = 16,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Legendary Guardian",
                                                    MinLevel = 1,
                                                    MaxRank = 4,
                                                    Level4Desc = "Legendary Guardian",
                                                    TltId = 4252,
                                                    Level3Desc = "Legendary Guardian",
                                                    TalentGroupId = 2,
                                                    GameCode = 4252,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Legendary Guardian",
                                                    TalentRowId = 11,
                                                    Level1Desc = "Legendary Guardian",
                                                    Name = "Legendary Guardian"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Runic Blessing",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Runic Blessing",
                                                    TltId = 4253,
                                                    Level3Desc = "Runic Blessing",
                                                    TalentGroupId = 2,
                                                    GameCode = 4253,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Runic Blessing",
                                                    TalentRowId = 11,
                                                    Level1Desc = "Runic Blessing",
                                                    Name = "Runic Blessing"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Second Wind",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Second Wind",
                                                    TltId = 4251,
                                                    Level3Desc = "Second Wind",
                                                    TalentGroupId = 2,
                                                    GameCode = 4251,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4241,
                                                    Level2Desc = "Second Wind",
                                                    TalentRowId = 11,
                                                    Level1Desc = "Second Wind",
                                                    Name = "Second Wind"
                                                },
                                            }
                                        },
                                    }
                                },
                                new TalentGroup 
                                {
                                    Index = 2,
                                    Name = "Utility",
                                    TltGroupId = 3,
                                    TalentRows = new List<TalentRow>
                                    {
                                        new TalentRow
                                        {
                                            Index = 2,
                                            TltGroupId = 3,
                                            PointsToActivate = 8,
                                            TltRowId = 15,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Culinary Master",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Culinary Master",
                                                    TltId = 4334,
                                                    Level3Desc = "Culinary Master",
                                                    TalentGroupId = 3,
                                                    GameCode = 4331,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4324,
                                                    Level2Desc = "Culinary Master",
                                                    TalentRowId = 15,
                                                    Level1Desc = "Culinary Master",
                                                    Name = "Culinary Master"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Greed",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Greed",
                                                    TltId = 4331,
                                                    Level3Desc = "Greed",
                                                    TalentGroupId = 3,
                                                    GameCode = 4331,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Greed",
                                                    TalentRowId = 15,
                                                    Level1Desc = "Greed",
                                                    Name = "Greed"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Runic Affinity",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Runic Affinity",
                                                    TltId = 4332,
                                                    Level3Desc = "Runic Affinity",
                                                    TalentGroupId = 3,
                                                    GameCode = 4332,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Runic Affinity",
                                                    TalentRowId = 15,
                                                    Level1Desc = "Runic Affinity",
                                                    Name = "Runic Affinity"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Vampirism",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Vampirism",
                                                    TltId = 4333,
                                                    Level3Desc = "Vampirism",
                                                    TalentGroupId = 3,
                                                    GameCode = 4333,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Vampirism",
                                                    TalentRowId = 15,
                                                    Level1Desc = "Vampirism",
                                                    Name = "Vampirism"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 5,
                                            TltRowId = 18,
                                            TltGroupId = 3,
                                            PointsToActivate = 20,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Wanderer",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Wanderer",
                                                    TltId = 4362,
                                                    Level3Desc = "Wanderer",
                                                    TalentGroupId = 3,
                                                    GameCode = 4362,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Wanderer",
                                                    TalentRowId = 18,
                                                    Level1Desc = "Wanderer",
                                                    Name = "Wanderer"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 0,
                                            TltGroupId = 3,
                                            TltRowId = 13,
                                            PointsToActivate = 0,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Phasewalker",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Phasewalker",
                                                    TltId = 4311,
                                                    Level3Desc = "Phasewalker",
                                                    TalentGroupId = 3,
                                                    GameCode = 4311,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Phasewalker",
                                                    TalentRowId = 13,
                                                    Level1Desc = "Phasewalker",
                                                    Name = "Phasewalker"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Fleet of Foot",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Fleet of Foot",
                                                    TltId = 4312,
                                                    Level3Desc = "Fleet of Foot",
                                                    TalentGroupId = 3,
                                                    GameCode = 4312,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Fleet of Foot",
                                                    TalentRowId = 13,
                                                    Level1Desc = "Fleet of Foot",
                                                    Name = "Fleet of Foot"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Meditation",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Meditation",
                                                    TltId = 4313,
                                                    Level3Desc = "Meditation",
                                                    TalentGroupId = 3,
                                                    GameCode = 4313,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Meditation",
                                                    TalentRowId = 13,
                                                    Level1Desc = "Meditation",
                                                    Name = "Meditation"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Scout",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Scout",
                                                    TltId = 4314,
                                                    Level3Desc = "Scout",
                                                    TalentGroupId = 3,
                                                    GameCode = 4314,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Scout",
                                                    TalentRowId = 13,
                                                    Level1Desc = "Scout",
                                                    Name = "Scout"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 3,
                                            TltRowId = 16,
                                            PointsToActivate = 12,
                                            TltGroupId = 3,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Inspiration",
                                                    MinLevel = 1,
                                                    MaxRank = 2,
                                                    Level4Desc = "Inspiration",
                                                    TltId = 4344,
                                                    Level3Desc = "Inspiration",
                                                    TalentGroupId = 3,
                                                    GameCode = 4344,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Inspiration",
                                                    TalentRowId = 16,
                                                    Level1Desc = "Inspiration",
                                                    Name = "Inspiration"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Wealth",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Wealth",
                                                    TltId = 4342,
                                                    Level3Desc = "Wealth",
                                                    TalentGroupId = 3,
                                                    GameCode = 4342,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Wealth",
                                                    TalentRowId = 16,
                                                    Level1Desc = "Wealth",
                                                    Name = "Wealth"
                                                },
                                                new Talent
                                                {
                                                    Index = 0,
                                                    Level5Desc = "Scavenger",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Scavenger",
                                                    TltId = 4341,
                                                    Level3Desc = "Scavenger",
                                                    TalentGroupId = 3,
                                                    GameCode = 4341,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4331,
                                                    Level2Desc = "Scavenger",
                                                    TalentRowId = 16,
                                                    Level1Desc = "Scavenger",
                                                    Name = "Scavenger"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Expanded Mind",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Expanded Mind",
                                                    TltId = 4343,
                                                    Level3Desc = "Expanded Mind",
                                                    TalentGroupId = 3,
                                                    GameCode = 4343,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Expanded Mind",
                                                    TalentRowId = 16,
                                                    Level1Desc = "Expanded Mind",
                                                    Name = "Expanded Mind"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 1,
                                            TltGroupId = 3,
                                            TltRowId = 14,
                                            PointsToActivate = 4,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Strength of Spirit",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Strength of Spirit",
                                                    TltId = 4323,
                                                    Level3Desc = "Strength of Spirit",
                                                    TalentGroupId = 3,
                                                    GameCode = 4323,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4313,
                                                    Level2Desc = "Strength of Spirit",
                                                    TalentRowId = 14,
                                                    Level1Desc = "Strength of Spirit",
                                                    Name = "Strength of Spirit"
                                                },
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Summoner's Insight",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Summoner's Insight",
                                                    TltId = 4322,
                                                    Level3Desc = "Summoner's Insight",
                                                    TalentGroupId = 3,
                                                    GameCode = 4322,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Summoner's Insight",
                                                    TalentRowId = 14,
                                                    Level1Desc = "Summoner's Insight",
                                                    Name = "Summoner's Insight"
                                                },
                                                new Talent
                                                {
                                                    Index = 3,
                                                    Level5Desc = "Alchemist",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Alchemist",
                                                    TltId = 4324,
                                                    Level3Desc = "Alchemist",
                                                    TalentGroupId = 3,
                                                    GameCode = 4324,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Alchemist",
                                                    TalentRowId = 14,
                                                    Level1Desc = "Alchemist",
                                                    Name = "Alchemist"
                                                },
                                            }
                                        },
                                        new TalentRow
                                        {
                                            Index = 4,
                                            TltRowId = 17,
                                            TltGroupId = 3,
                                            PointsToActivate = 16,
                                            Talents = new List<Talent>
                                            {
                                                new Talent
                                                {
                                                    Index = 1,
                                                    Level5Desc = "Bandit",
                                                    MinLevel = 1,
                                                    MaxRank = 1,
                                                    Level4Desc = "Bandit",
                                                    TltId = 4352,
                                                    Level3Desc = "Bandit",
                                                    TalentGroupId = 3,
                                                    GameCode = 4352,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = 4342,
                                                    Level2Desc = "Bandit",
                                                    TalentRowId = 17,
                                                    Level1Desc = "Bandit",
                                                    Name = "Bandit"
                                                },
                                                new Talent
                                                {
                                                    Index = 2,
                                                    Level5Desc = "Intelligence",
                                                    MinLevel = 1,
                                                    MaxRank = 3,
                                                    Level4Desc = "Intelligence",
                                                    TltId = 4353,
                                                    Level3Desc = "Intelligence",
                                                    TalentGroupId = 3,
                                                    GameCode = 4353,
                                                    MinTier = 1,
                                                    PrereqTalentGameCode = null,
                                                    Level2Desc = "Intelligence",
                                                    TalentRowId = 17,
                                                    Level1Desc = "Intelligence",
                                                    Name = "Intelligence"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                    SpellBookConfig = new List<RuneSlot> 
                            {
                                new RuneSlot
                                {
                                    Id = 27,
                                    MinLevel = 29,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 19,
                                    MinLevel = 3,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 2,
                                    MinLevel = 4,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 15,
                                    MinLevel = 25,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 17,
                                    MinLevel = 25,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 28,
                                    MinLevel = 10,
                                    RuneType = new RuneType
                                    {
                                        Id = 7,
                                        Name = "Black"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 24,
                                    MinLevel = 19,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 10,
                                    MinLevel = 2,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 25,
                                    MinLevel = 23,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 14,
                                    MinLevel = 15,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 23,
                                    MinLevel = 16,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 4,
                                    MinLevel = 11,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 30,
                                    MinLevel = 30,
                                    RuneType = new RuneType
                                    {
                                        Id = 7,
                                        Name = "Black"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 6,
                                    MinLevel = 17,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 20,
                                    MinLevel = 6,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 8,
                                    MinLevel = 24,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 3,
                                    MinLevel = 7,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 5,
                                    MinLevel = 14,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 12,
                                    MinLevel = 8,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 16,
                                    MinLevel = 22,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 26,
                                    MinLevel = 26,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 13,
                                    MinLevel = 12,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 1,
                                    MinLevel = 1,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 21,
                                    MinLevel = 9,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 9,
                                    MinLevel = 27,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 7,
                                    MinLevel = 21,
                                    RuneType = new RuneType
                                    {
                                        Id = 1,
                                        Name = "Red"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 11,
                                    MinLevel = 5,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 29,
                                    MinLevel = 20,
                                    RuneType = new RuneType
                                    {
                                        Id = 7,
                                        Name = "Black"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 22,
                                    MinLevel = 13,
                                    RuneType = new RuneType
                                    {
                                        Id = 5,
                                        Name = "Blue"
                                    }
                                },
                                new RuneSlot
                                {
                                    Id = 18,
                                    MinLevel = 28,
                                    RuneType = new RuneType
                                    {
                                        Id = 3,
                                        Name = "Yellow"
                                    }
                                },
                            }
                },
                IpBalance = 0,
                ReconnectInfo = null,
                Locales = new List<string> { "en_US" },
                SimpleMessages = null,
                AllSummonerData = new AllSummonerData
                {
                    SpellBook = new SpellBookDTO
                    {
                        SummonerId = 1.0,
                        DateString = "Wed Jul 17 23:05:42 PDT 2013",
                        BookPages = new List<SpellBookPageDTO>
                                {
                                    new SpellBookPageDTO
                                    {
                                        Current = true,
                                        SummonerId = 1.0,
                                        PageId = 2.0,
                                        CreateDate = DateTime.Now,
                                        Name = "Rune Page 1",
                                        SlotEntries = new List<SlotEntry>()
                                    },
                                    new SpellBookPageDTO
                                    {
                                        Current = true,
                                        SummonerId = 1.0,
                                        PageId = 3.0,
                                        CreateDate = DateTime.Now,
                                        Name = "Rune Page 2",
                                        SlotEntries = new List<SlotEntry>()
                                    }
                                }
                    },
                    SummonerDefaultSpells = new SummonerDefaultSpells //TODO
                    {
                        SummonerId = 1.0,
                        SummonerDefaultSpellMap = new AsObject()
                    },
                    SummonerTalentsAndPoints = new SummonerTalentsAndPoints
                    {
                        CreateDate = DateTime.Now,
                        SummonerId = 1.0,
                        TalentPoints = 1,
                        ModifyDate = DateTime.Now,
                    },
                    Summoner = new Summoner
                    {
                        InternalName = "Poro User",
                        DisplayEloQuestionaire = false,
                        AcctId = 1.0,
                        PreviousSeasonHighestTier = "UNRANKED",
                        PreviousSeasonHighestTeamReward = 0,
                        ProfileIconId = 0,
                        AdvancedTutorialFlag = false,
                        HelpFlag = false,
                        LastGameDate = DateTime.Now,
                        RevisionDate = DateTime.Now,
                        Name = "Poro User",
                        NameChangeFlag = false,
                        RevisionId = 0,
                        SumId = 1.0,
                        TutorialFlag = true
                    },
                    MasteryBook = new MasteryBookDTO
                    {
                        SummonerId = 1.0,
                        DateString = "Wed Apr 23 00:33:57 PDT 2014",
                        BookPages = new List<MasteryBookPageDTO>
                                {
                                    new MasteryBookPageDTO
                                    {
                                        Current = true,
                                        SummonerId = 1.0,
                                        PageId = 1.0,
                                        Name = "Mastery Page 1",
                                        TalentEntries = new List<TalentEntry>()
                                    }
                                }
                    },
                    SummonerLevel = new SummonerLevel
                    {
                        ExpTierMod = 1.0,
                        GrantRp = 0.0,
                        ExpForLoss = 43.0,
                        SummonerTier = 1.0,
                        InfTierMod = 1.0,
                        ExpToNextLevel = 90.0,
                        ExpForWin = 72.0,
                        Level = 999.0
                    },
                    SummonerLevelAndPoints = new SummonerLevelAndPoints
                    {
                        InfPoints = 0.0,
                        ExpPoints = 0.0,
                        SummonerId = 1.0,
                        SummonerLevel = 999.0
                    }
                },
                CustomMinutesLeftToday = -1,
                PlatformGameLifecycleDTO = null,
                CoOpVsAiMinutesLeftToday = 180,
                BingeData = null,
                InGhostGame = false,
                BingePreventionSystemEnabledForClient = false,
                PendingBadges = 0,
                BroadcastNotification = null,
                MinutesUntilMidnight = 0,
                TimeUntilFirstWinOfDay = 0,
                CoOpVsAiMsecsUntilReset = 79200000.0,
                BingeMinutesRemaining = 0,
                PendingKudosDTO = new PendingKudosDTO
                {
                    PendingCounts = new int[5] { 0, 0, 0, 0, 0 }
                },
                LeaverBusterPenaltyTime = 60,
                PlatformId = "OC1",
                EmailStatus = "validated",
                MatchMakingEnabled = true,
                MinutesUntilShutdownEnabled = false,
                RpBalance = 0,
                ShowEmailVerificationPopup = false,
                BingeIsPlayerInBingePreventionWindow = false,
                MinorShutdownEnforced = false,
                CompetitiveRegion = "OCE",
                CustomMsecsUntilReset = -1,
                ClientSystemStates = new ClientSystemStatesNotification
                {
                    Json = "{\"championTradeThroughLCDS\":true,\"practiceGameEnabled\":true,\"advancedTutorialEnabled\":true,\"minNumPlayersForPracticeGame\":1,\"practiceGameTypeConfigIdList\":[1,4,6,2],\"freeToPlayChampionIdList\":[14,18,20,34,41,42,43,51,54,58,61,64,68,89,104,105,111,161,236,267],\"freeToPlayChampionForNewPlayersIdList\":[110,21,86,22,102,63,13,122,55,89],\"freeToPlayChampionsForNewPlayersMaxLevel\":5,\"inactiveChampionIdList\":[],\"gameModeToInactiveSpellIds\":{\"CLASSIC\":[17,31,30],\"ASCENSION\":[9,10,11,12,17,16,20,31,30],\"KINGPORO\":[1,2,3,4,6,7,9,10,11,12,13,14,17,16,21,20],\"ALL_GAME_MODES_DISABLED_SPELLS_KEY\":[9,16,20],\"ARAM\":[2,9,10,11,12,17,31,30],\"TUTORIAL\":[17,20,31,30],\"ODIN\":[9,10,11,12,31,30]},\"inactiveSpellIdList\":[9,16,20],\"inactiveTutorialSpellIdList\":[17,20,31,30],\"inactiveClassicSpellIdList\":[17,31,30],\"inactiveOdinSpellIdList\":[9,10,11,12,31,30],\"inactiveAramSpellIdList\":[2,9,10,11,12,17,31,30],\"enabledQueueIdsList\":[2,4,8,31,32,33,42,61,65],\"unobtainableChampionSkinIDList\":[1001,1002,1003,1007,3002,4001,4003,4007,6002,7003,8003,9002,9004,9007,10001,10003,10005,12001,12003,12005,13001,13004,13005,13006,13008,14001,15002,15003,15005,15006,17001,17003,17007,18001,18002,18003,18006,19001,19002,19005,20001,20002,20006,21004,23001,23006,24001,24003,24004,25006,26001,26004,27001,27006,28002,29001,29002,29003,30001,31001,32001,32002,32004,33001,33003,34001,35003,35004,36001,36002,36004,36007,37001,37003,38001,40004,41003,41004,42001,42002,42003,43003,44001,45002,45007,48003,51003,51006,53001,53002,53005,53007,54001,55002,55004,55007,56004,57003,57004,58005,59004,60002,61002,61004,63004,74001,74004,75004,76001,76002,76005,78001,78002,78003,78004,79001,79003,81001,81002,81006,82001,84002,84003,85002,86002,89003,90001,92004,92005,96001,96002,96004,98001,98002,98006,103003,104003,104004,113003,114003,115004,117004,120003,412002],\"archivedStatsEnabled\":true,\"queueThrottleDTO\":{},\"gameMapEnabledDTOList\":[{\"gameMapId\":10,\"minPlayers\":1},{\"gameMapId\":12,\"minPlayers\":1},{\"gameMapId\":11,\"minPlayers\":1},{\"gameMapId\":8,\"minPlayers\":1}],\"storeCustomerEnabled\":true,\"runeUniquePerSpellBook\":false,\"tribunalEnabled\":true,\"observerModeEnabled\":true,\"spectatorSlotLimit\":4,\"clientHeartBeatRateSeconds\":120,\"observableGameModes\":[\"ODIN_RANKED_TEAM\",\"TT_5x5\",\"RANKED_PREMADE_5x5\",\"CAP_1x1\",\"FEATURED\",\"ONEFORALL_1x1\",\"ONEFORALL_5x5\",\"RANKED_SOLO_5x5\",\"COUNTER_PICK\",\"ASCENSION\",\"ARAM_UNRANKED_5x5\",\"RANKED_PREMADE_3x3\",\"CAP_5x5\",\"RANKED_SOLO_3x3\",\"SR_6x6\",\"HEXAKILL\",\"RANKED_TEAM_3x3\",\"FIRSTBLOOD_2x2\",\"ODIN_UNRANKED\",\"RANKED_SOLO_1x1\",\"KING_PORO\",\"ARAM_UNRANKED_2x2\",\"ODIN_RANKED_SOLO\",\"ARAM_UNRANKED_1x1\",\"FIRSTBLOOD_1x1\",\"ARAM_UNRANKED_3x3\",\"RANKED_TEAM_5x5\",\"URF\",\"NORMAL_3x3\",\"NORMAL\",\"ARAM_UNRANKED_6x6\"],\"observableCustomGameModes\":\"ALL\",\"teamServiceEnabled\":true,\"leagueServiceEnabled\":true,\"modularGameModeEnabled\":false,\"riotDataServiceDataSendProbability\":0.2,\"displayPromoGamesPlayedEnabled\":false,\"masteryPageOnServer\":false,\"maxMasteryPagesOnServer\":20,\"tournamentSendStatsEnabled\":true,\"replayServiceAddress\":\"\",\"kudosEnabled\":true,\"buddyNotesEnabled\":true,\"localeSpecificChatRoomsEnabled\":false,\"replaySystemStates\":{\"replayServiceEnabled\":false,\"replayServiceAddress\":\"\",\"endOfGameEnabled\":false,\"matchHistoryEnabled\":true,\"getReplaysTabEnabled\":true,\"backpatchingEnabled\":false},\"sendFeedbackEventsEnabled\":false,\"knownGeographicGameServerRegions\":[\"\"],\"leaguesDecayMessagingEnabled\":false,\"currentSeason\":5}"
                },
                GameTypeConfigs = new List<GameTypeConfigDTO>
                {
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        PostPickTimerDuration = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        Id = 1,
                        DuplicatePick = false,
                        ExclusivePick = false,
                        Name = "GAME_CFG_PICK_BLIND",
                        PickMode = "SimulPickStrategy",
                        MainPickTimerDuration = 93
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = true,
                        BanTimerDuration = 38,
                        MaxAllowableBans = 6,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 33,
                        Id = 2,
                        DuplicatePick = false,
                        ExclusivePick = true,
                        Name = "GAME_CFG_DRAFT_STD",
                        PickMode = "DraftModeSinglePickStrategy",
                        MainPickTimerDuration = 43
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = true,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 33,
                        Id = 3,
                        DuplicatePick = false,
                        ExclusivePick = true,
                        Name = "GAME_CFG_DRAFT_NOBAN",
                        PickMode = "DraftModeSinglePickStrategy",
                        MainPickTimerDuration = 43
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = true,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 70,
                        Id = 4,
                        DuplicatePick = false,
                        ExclusivePick = true,
                        Name = "GAME_CFG_PICK_RANDOM",
                        PickMode = "AllRandomPickStrategy",
                        MainPickTimerDuration = 0
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 13,
                        Id = 5,
                        DuplicatePick = false,
                        ExclusivePick = false,
                        Name = "GAME_CFG_PICK_SIMUL",
                        PickMode = "SimulPickStrategy",
                        MainPickTimerDuration = 93
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = true,
                        BanTimerDuration = 33,
                        MaxAllowableBans = 6,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 63,
                        Id = 6,
                        DuplicatePick = false,
                        ExclusivePick = true,
                        Name = "GAME_CFG_DRAFT_TOURNAMENT",
                        PickMode = "DraftModeSinglePickStrategy",
                        MainPickTimerDuration = 63
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 28,
                        MaxAllowableBans = 6,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 43,
                        Id = 7,
                        DuplicatePick = false,
                        ExclusivePick = false,
                        Name = "GAME_CFG_PICK_SIMUL_TD",
                        PickMode = "SimulPickStrategy",
                        MainPickTimerDuration = 53
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 0,
                        Id = 10,
                        DuplicatePick = false,
                        ExclusivePick = false,
                        Name = "GAME_CFG_BASIC_TUTORIAL",
                        PickMode = "SimulPickStrategy",
                        MainPickTimerDuration = 93
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 0,
                        Id = 11,
                        DuplicatePick = false,
                        ExclusivePick = false,
                        Name = "GAME_CFG_ADV_TUTORIAL",
                        PickMode = "SimulPickStrategy",
                        MainPickTimerDuration = 900
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 0,
                        Id = 12,
                        DuplicatePick = false,
                        ExclusivePick = false,
                        Name = "GAME_CFG_CAP",
                        PickMode = "SkipPickStrategy",
                        MainPickTimerDuration = 0
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = true,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 70,
                        Id = 13,
                        DuplicatePick = false,
                        ExclusivePick = true,
                        Name = "GAME_CFG_BLIND_RANDOM",
                        PickMode = "AllRandomPickStrategy",
                        MainPickTimerDuration = 0
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 38,
                        MaxAllowableBans = 6,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = true,
                        PostPickTimerDuration = 63,
                        Id = 14,
                        DuplicatePick = true,
                        ExclusivePick = false,
                        Name = "GAME_CFG_BLIND_DUPE",
                        PickMode = "OneTeamVotePickStrategy",
                        MainPickTimerDuration = 43
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 0,
                        MaxAllowableBans = 0,
                        CrossTeamChampionPool = true,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 63,
                        Id = 15,
                        DuplicatePick = true,
                        ExclusivePick = false,
                        Name = "GAME_CFG_CROSS_DUPE",
                        PickMode = "AllTeamVotePickStrategy",
                        MainPickTimerDuration = 43
                    },
                    new GameTypeConfigDTO
                    {
                        AllowTrades = false,
                        BanTimerDuration = 28,
                        MaxAllowableBans = 6,
                        CrossTeamChampionPool = false,
                        TeamChampionPool = false,
                        PostPickTimerDuration = 13,
                        Id = 16,
                        DuplicatePick = false,
                        ExclusivePick = true,
                        Name = "GAME_CFG_BLIND_DRAFT_ST",
                        PickMode = "SimulPickStrategy",
                        MainPickTimerDuration = 53
                    },
                }
            };

            e.ReturnRequired = true;
            e.Data = packet;

            return e;
        }
    }
}
