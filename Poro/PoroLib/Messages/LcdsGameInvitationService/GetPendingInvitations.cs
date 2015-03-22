using RtmpSharp.IO.AMF3;
using RtmpSharp.Messaging;
using System.Collections.Generic;

namespace PoroLib.Messages.LcdsGameInvitationService
{
    class GetPendingInvitations : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            e.ReturnRequired = true;
            e.Data = new ArrayCollection();

            return e;
        }
    }
}
