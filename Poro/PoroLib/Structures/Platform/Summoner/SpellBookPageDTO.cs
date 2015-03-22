using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using System;
using System.Collections.Generic;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.spellbook.SpellBookPageDTO")]
    public class SpellBookPageDTO
    {
        [SerializedName("slotEntries")]
        public ArrayCollection SlotEntries { get; set; }
        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }
        [SerializedName("createDate")]
        public DateTime CreateDate { get; set; }
        [SerializedName("name")]
        public String Name { get; set; }
        [SerializedName("pageId")]
        public Double PageId { get; set; }
        [SerializedName("current")]
        public Boolean Current { get; set; }
    }
}
