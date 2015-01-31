using PoroLib.Structures;
using RtmpSharp.Messaging;
using System.Collections.Generic;

namespace PoroLib.Messages.MatchmakerService
{
    class GetAvailableQueues : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            List<GameQueueConfig> data = new List<GameQueueConfig>
            {
                new GameQueueConfig {
                    BlockedMinutesThreshold = 60,
                    Ranked = false,
                    MinimumParticipantListSize = 1,
                    MaxLevel = 100,
                    ThresholdEnabled = false,
                    GameTypeConfigId = 1,
                    MinLevel = 3,
                    QueueState = "ON",
                    Type = "NORMAL",
                    CacheName = "matching-queue-NORMAL-5x5-game-queue",
                    Id = 2.0,
                    QueueBonusKey = "normalQueueBonuses",
                    MaxSummonerLevelForFWOTD = 100,
                    QueueStateString = "ON",
                    PointsConfigKey = "normalSummonersRift",
                    TeamOnly = false,
                    MinimumQueueDodgeDelayTime = 8000,
                    RandomizeTeamSides = false,
                    SupportedMapIds = new List<int>{ 11, 1 },
                    GameMode = "CLASSIC",
                    TypeString = "NORMAL",
                    NumPlayersPerTeam = 5,
                    DisallowFreeChampions = false,
                    MaximumParticipantListSize = 5,
                    MapSelectionAlgorithm = "FIRST",
                    BotsCanSpawnOnBlueSide = true,
                    GameMutators = new List<string>{ "HudSkin(Freljord)" },
                    ThresholdSize = 2147483647.0,
                    MatchingThrottleConfig = new MatchingThrottleConfig
                    {
                        CacheName = "",
                        Limit = 2147483647.0,
                        MatchingThrottleProperties = new List<object>()
                    }
                }
            };
            e.ReturnRequired = true;
            e.Data = data;

            return e;
        }
    }
}
