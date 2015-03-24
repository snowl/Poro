using PoroLib.Structures;
using RtmpSharp.IO.AMF3;
using RtmpSharp.Messaging;
using System;
using System.Collections.Generic;

namespace PoroLib.Messages.MatchmakerService
{
    class AttachToQueue: IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            SearchingForMatchNotification notification = new SearchingForMatchNotification
            {
                PlayerJoinFailures = new ArrayCollection
                {
                    new QueueDisabled
                    {
                        Message = "QUEUE_DISABLED",
                        QueueId = 1
                    }
                },
                GhostGameSummoners = new ArrayCollection(),
                JoinedQueues = new ArrayCollection()
            };

            e.ReturnRequired = true;
            e.Data = notification;

            return e;
        }
    }
}
