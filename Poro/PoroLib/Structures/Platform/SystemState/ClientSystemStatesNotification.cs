﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.systemstate.ClientSystemStatesNotification")]
    public class ClientSystemStatesNotification : IExternalizable
    {
        [SerializedName("Json")]
        public string Json { get; set; }

        public bool championTradeThroughLCDS { get; set; }
        public bool practiceGameEnabled { get; set; }
        public bool advancedTutorialEnabled { get; set; }
        public double minNumPlayersForPracticeGame { get; set; }
        public List<long> practiceGameTypeConfigIdList { get; set; }
        public List<long> freeToPlayChampionIdList { get; set; }
        public List<long> freeToPlayChampionForNewPlayersIdList { get; set; }
        public double freeToPlayChampionsForNewPlayersMaxLevel { get; set; }
        public List<long> inactiveChampionIdList { get; set; }
        public object gameModeToInactiveSpellIds { get; set; }
        public List<long> inactiveSpellIdList { get; set; }
        public List<long> inactiveClassicSpellIdList { get; set; }
        public List<long> inactiveOdinSpellIdList { get; set; }
        public List<long> inactiveAramSpellIdList { get; set; }
        public List<long> inactiveTutorialSpellIdList { get; set; }
        public List<long> enabledQueueIdsList { get; set; }
        public List<long> unobtainableChampionSkinIDList { get; set; }
        public bool archivedStatsEnabled { get; set; }
        public object queueThrottleDTO { get; set; }
        public object gameMapEnabledDTOList { get; set; }
        public bool storeCustomerEnabled { get; set; }
        public bool runeUniquePerSpellBook { get; set; }
        public bool tribunalEnabled { get; set; }
        public bool observerModeEnabled { get; set; }
        public double spectatorSlotLimit { get; set; }
        public double clientHeartBeatRateSeconds { get; set; }
        public List<string> observableGameModes { get; set; }
        public string observableCustomGameModes { get; set; }
        public bool teamServiceEnabled { get; set; }
        public bool leagueServiceEnabled { get; set; }
        public bool modularGameModeEnabled { get; set; }
        public double riotDataServiceDataSendProbability { get; set; }
        public bool displayPromoGamesPlayedEnabled { get; set; }
        public bool masteryPageOnServer { get; set; }
        public double maxMasteryPagesOnServer { get; set; }
        public bool tournamentSendStatsEnabled { get; set; }
        public object replayServiceAddress { get; set; }
        public bool kudosEnabled { get; set; }
        public bool buddyNotesEnabled { get; set; }
        public bool localeSpecificChatRoomsEnabled { get; set; }
        public object replaySystemStates { get; set; }
        public bool sendFeedbackEventsEnabled { get; set; }
        public object knownGeographicGameServerRegions { get; set; }
        public bool leaguesDecayMessagingEnabled { get; set; }
        public object tournamentShortCodesEnabled { get; set; }
        public double currentSeason { get; set; }

        public void ReadExternal(IDataInput input)
        {
            Json = input.ReadUtf((int)input.ReadUInt32());

            Dictionary<string, object> deserializedJSON = JsonConvert.DeserializeObject<Dictionary<string, object>>(Json);

            Type classType = typeof(ClientSystemStatesNotification);
            foreach (KeyValuePair<string, object> keyPair in deserializedJSON)
            {
                var f = classType.GetProperty(keyPair.Key);
                Type valueType = keyPair.Value.GetType();
                if (valueType == typeof(JArray))
                {
                    JArray myValue = (JArray)keyPair.Value;

                    if (myValue.Count == 0) //If the array is empty don't try parsing
                        continue;

                    if (myValue[0].GetType() != typeof(JValue)) //Don't parse complex arrays
                    {
                        f.SetValue(this, keyPair.Value);
                        continue;
                    }

                    JValue x = (JValue)myValue[0];
                    Type listType = x.Value.GetType();
                    Type genericListType = typeof(List<>).MakeGenericType(listType);

                    f.SetValue(this, myValue.ToObject(genericListType));
                }
                else
                {
                    f.SetValue(this, keyPair.Value);
                }
            }
        }

        public void WriteExternal(IDataOutput output)
        {
            var bytes = Encoding.UTF8.GetBytes(Json);

            output.WriteInt32(bytes.Length);
            output.WriteBytes(bytes);
        }
    }
}