using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.matchmaking.QueueDisabled")]
    public class QueueDisabled
    {
        [SerializedName("queueId")]
        public Double QueueId { get; set; }

        [SerializedName("message")]
        public string Message { get; set; }

        [SerializedName("summoner")]
        public Summoner Summoner { get; set; }
    }
}
