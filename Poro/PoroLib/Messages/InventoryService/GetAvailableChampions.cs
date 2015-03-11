using PoroLib.Data.SQLite;
using PoroLib.Structures;
using RtmpSharp.Messaging;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PoroLib.Messages.InventoryService
{
    class GetAvailableChampions : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            List<ChampionDTO> champions = new List<ChampionDTO>();

            foreach (Champions champ in PoroServer._data.Champions)
            {
                var champDTO = new ChampionDTO
                {
                    Owned = true,
                    ChampionID = champ.id,
                    Active = true,
                    BotEnabled = true,
                    RankedPlayEnabled = true
                };

                champDTO.ChampionSkins = PoroServer._data.ChampionSkins.Where(x => x.championId == champ.id).Select(skins => new ChampionSkinDTO
                {
                    ChampionID = champ.id,
                    SkinID = skins.id,
                    StillObtainable = true,
                    Owned = true
                }).ToList();

                champions.Add(champDTO);
            }

            e.ReturnRequired = true;
            e.Data = champions;

            return e;
        }
    }
}
