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
                    TalentTree = PoroServer._data.TalentTree,
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
                        SummonerId = int.MaxValue - 1,
                        DateString = "Wed Jul 17 23:05:42 PDT 2013",
                        BookPages = new List<SpellBookPageDTO>
                                {
                                    new SpellBookPageDTO
                                    {
                                        Current = true,
                                        SummonerId = int.MaxValue - 1,
                                        PageId = 2.0,
                                        CreateDate = DateTime.Now,
                                        Name = "Rune Page 1",
                                        SlotEntries = new List<SlotEntry>()
                                    },
                                    new SpellBookPageDTO
                                    {
                                        Current = true,
                                        SummonerId = int.MaxValue - 1,
                                        PageId = 3.0,
                                        CreateDate = DateTime.Now,
                                        Name = "Rune Page 2",
                                        SlotEntries = new List<SlotEntry>()
                                    }
                                }
                    },
                    SummonerDefaultSpells = new SummonerDefaultSpells //TODO
                    {
                        SummonerId = int.MaxValue - 1,
                        SummonerDefaultSpellMap = new AsObject()
                    },
                    SummonerTalentsAndPoints = new SummonerTalentsAndPoints
                    {
                        CreateDate = DateTime.Now,
                        SummonerId = int.MaxValue - 1,
                        TalentPoints = 1,
                        ModifyDate = DateTime.Now,
                    },
                    Summoner = new Summoner
                    {
                        InternalName = "Poro User",
                        DisplayEloQuestionaire = false,
                        AcctId = int.MaxValue - 2,
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
                        SumId = int.MaxValue - 1,
                        TutorialFlag = true
                    },
                    MasteryBook = new MasteryBookDTO
                    {
                        SummonerId = int.MaxValue - 1,
                        DateString = "Wed Apr 23 00:33:57 PDT 2014",
                        BookPages = new List<MasteryBookPageDTO>
                                {
                                    new MasteryBookPageDTO
                                    {
                                        Current = true,
                                        SummonerId = int.MaxValue - 1,
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
                        SummonerId = int.MaxValue - 1,
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
