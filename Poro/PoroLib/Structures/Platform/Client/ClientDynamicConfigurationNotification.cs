using RtmpSharp.IO;
using System;

namespace PoroLib.Structures
{
    [Serializable]
    [SerializedName("com.riotgames.platform.client.dynamic.configuration.ClientDynamicConfigurationNotification")]
    public class ClientDynamicConfigurationNotification
    {
        [SerializedName("configs")]
        public string Config { get; set; }

        [SerializedName("delta")]
        public Boolean Delta { get; set; }
    }
}
