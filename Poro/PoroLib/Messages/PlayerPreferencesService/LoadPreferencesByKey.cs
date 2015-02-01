using PoroLib.Structures;
using RtmpSharp.Messaging;

namespace PoroLib.Messages.PlayerPreferencesService
{
    class LoadPreferencesByKey : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            e.ReturnRequired = true;
            e.Data = null;

            return e;
        }
    }
}
