using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoroLib.Data.JSON;
using PoroLib.Data.SQLite;
using PoroLib.Structures;
using RtmpSharp.IO.AMF3;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PoroLib.Data
{
    public class DataLoader
    {
        public bool _hasLoaded;
        public List<Champions> Champions;
        public List<ChampionSkins> ChampionSkins;
        public ArrayCollection TalentTree;
        public ArrayCollection RuneTree;

        private Dictionary<string, int> _masterySort = new Dictionary<string, int> { { "Offense", 1 }, { "Defense", 2 }, { "Utility", 3 } };

        /// <summary>
        /// Load the data for packets for League of Legends on patcher launch
        /// </summary>
        public void LoadData()
        {
            //Only load the data once
            if (_hasLoaded)
                return;

            _hasLoaded = true;

            //Load the gameStats from the client (the client location is loaded when the patcher runes)
            SQLiteConnection conn = new SQLiteConnection(Path.Combine(PoroServer.ClientLocation, "assets", "data", "gameStats", "gameStats_en_US.sqlite"));

            //Generate the champion list
            Champions = (from s in conn.Table<Champions>() orderby s.name select s).ToList();

            //Generate the champion skin list
            ChampionSkins = (from s in conn.Table<ChampionSkins>() select s).ToList();

            //Close the SQLite connection
            conn.Close();

            using (WebClient client = new WebClient())
            {
                //Download latest ddragon
                string Versions = client.DownloadString("http://ddragon.leagueoflegends.com/realms/euw.js");
                //Get the ddragon version
                Versions = Versions.Replace(";", "").Replace("Riot.DDragon.m=", "");
                JObject DDragonObject = JsonConvert.DeserializeObject<JObject>(Versions);
                JObject DDragonVersions = DDragonObject["n"] as JObject;

                //Download the latest mastery daata
                string MasteryVersion = DDragonVersions["mastery"].ToString();
                string MasteryData = client.DownloadString(string.Format("http://ddragon.leagueoflegends.com/cdn/{0}/data/en_US/mastery.json", MasteryVersion));

                #region Mastery loading
                Masteries mData = JsonConvert.DeserializeObject<Masteries>(MasteryData);
                TalentTree = new ArrayCollection();

                //Parse the data and convert it into a type that is sent in the LoginDataPacket
                foreach (KeyValuePair<string, List<List<MasteryLite>>> mastery in mData.tree)
                {
                    TalentGroup group = new TalentGroup
                    {
                        Name = mastery.Key,
                        TalentRows = new ArrayCollection(),
                        TltGroupId = _masterySort[mastery.Key],
                        Index = _masterySort[mastery.Key] - 1
                    };

                    for (int i = 0; i < mastery.Value.Count; i++)
                    {
                        ArrayCollection talentList = new ArrayCollection();
                        List<MasteryLite> masteryList = mastery.Value[i];
                        for (int j = 0; j < masteryList.Count; j++)
                        {
                            if (masteryList[j] == null)
                                continue;

                            var data = mData.data[Convert.ToInt32(masteryList[j].masteryId)];
                            Talent t = new Talent
                            {
                                Index = j,
                                Name = data.name,
                                Level1Desc = data.name,
                                Level2Desc = data.name,
                                Level3Desc = data.name,
                                Level4Desc = data.name,
                                Level5Desc = data.name,
                                GameCode = data.id,
                                TltId = data.id,
                                MaxRank = data.ranks,
                                MinLevel = 1,
                                MinTier = 1,
                                TalentGroupId = group.TltGroupId,
                                TalentRowId = (i + 1) * group.TltGroupId
                            };

                            if (data.preReq != "0")
                                t.PrereqTalentGameCode = Convert.ToInt32(data.preReq);

                            talentList.Add(t);
                        }

                        TalentRow row = new TalentRow
                        {
                            Index = i,
                            Talents = talentList,
                            PointsToActivate = i * 4,
                            TltRowId = (i + 1) * group.TltGroupId,
                            TltGroupId = group.TltGroupId
                        };

                        group.TalentRows.Add(row);
                    }

                    TalentTree.Add(group);
                }
                #endregion

                #region Rune Loading
                RuneTree = new ArrayCollection();

                //This code is... bad. 
                int Modifier = 0; //Skip 10, 20, 30
                int Take = 3; //Take one each loop and it will increase what it starts from (1 - 2 - 3)
                //Loop from 1-9 and do it 3 times to generate the red, yellow and blue runes
                for (int i = 1; i <= 9; i++)
                {
                    //At 10, 20 and 30 you need to increment the min level.
                    if ((i - 1) % 3 == 0 && i != 1)
                    {
                        Modifier += 1;
                    }

                    //The id goes past 9 so add the required amount that we have looped
                    int IdAdd = (Math.Abs(Take - 3) * 10);
                    //Take the amount that it has gone over
                    IdAdd -= Math.Abs(Take - 3);

                    RuneSlot slot = new RuneSlot()
                    {
                        Id = IdAdd + i,
                        RuneType = new RuneType(),
                        MinLevel = (3 * i + 1) - Take + Modifier
                    };

                    if (Take == 3)
                    {
                        slot.RuneType.Name = "Red";
                        slot.RuneType.Id = 1;
                    }
                    else if (Take == 2)
                    {
                        slot.RuneType.Name = "Yellow";
                        slot.RuneType.Id = 3;
                    }
                    else
                    {
                        slot.RuneType.Name = "Blue";
                        slot.RuneType.Id = 5;
                    }

                    RuneTree.Add(slot);

                    //Re do the loop, reset the modifier and take one from the take so the min level starts off one integer higher than last time
                    if (i == 9 && Take > 1)
                    {
                        Take -= 1;
                        i = 0;
                        Modifier = 0;
                    }
                }

                //Add black runes
                for (int i = 1; i <= 3; i++)
                {
                    RuneSlot slot = new RuneSlot()
                    {
                        Id = 27 + i, //Start id from 27 since thats where we left off
                        RuneType = new RuneType
                        {
                            Id = 7,
                            Name = "Black"
                        },
                        MinLevel = 10 * i
                    };

                    RuneTree.Add(slot);
                }

                #endregion
            }

            Console.WriteLine("[LOG] Loaded League of Legends Data");
        }
    }
}
