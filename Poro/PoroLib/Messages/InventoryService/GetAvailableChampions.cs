using PoroLib.Structures;
using RtmpSharp.Messaging;
using System;
using System.Collections.Generic;

namespace PoroLib.Messages.InventoryService
{
    class GetAvailableChampions : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            List<ChampionDTO> champions = new List<ChampionDTO>
            {
                new ChampionDTO
                {
                    Owned = true,
                    FreeToPlayReward = false,
                    ChampionID = 1,
                    FreeToPlay = false,
                    EndDate = 0.0,
                    Active = true,
                    BotEnabled = true,
                    WinCountRemaining = 0,
                    PurchaseDate = 0.0,
                    RankedPlayEnabled = true,
                    PurchaseDateTime = 0.0,
                    ChampionSkins = new List<ChampionSkinDTO>
                    {
                        new ChampionSkinDTO
                        {
                            EndDate = 0.0,
                            ChampionID = 1,
                            FreeToPlayReward = false,
                            SkinID = 1001,
                            LastSelected = false,
                            StillObtainable = false,
                            Owned = false,
                            PurchaseDate = 0.0,
                            WinCountRemaining = 0
                        }
                    }
                }
            };

            e.ReturnRequired = true;
            e.Data = champions;

            return e;
        }
    }
}
