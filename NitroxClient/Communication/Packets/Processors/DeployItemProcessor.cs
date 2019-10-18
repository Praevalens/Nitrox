using NitroxClient.Communication.Packets.Processors.Abstract;
using NitroxClient.GameLogic;
using NitroxClient.GameLogic.Helper;
using NitroxClient.MonoBehaviours;
using NitroxModel.DataStructures.Util;
using NitroxModel.Packets;
using UnityEngine;

namespace NitroxClient.Communication.Packets.Processors
{
    public class DeployItemProcessor : ClientPacketProcessor<DeployItem>
    {
        private readonly Entities entities;

        public DeployItemProcessor()
        {
        }

        public override void Process(DeployItem deployedItem)
        {
            Optional<GameObject> opGameObject = NitroxIdentifier.GetObjectFrom(deployedItem.Id);

            if (opGameObject.IsPresent())
            {
                GameObject deployedItemLocalGameObject = opGameObject.Get();
                deployedItemLocalGameObject.SendMessage("OnToolUseAnim", new ItemDeployingGUIHand(deployedItem.DeployPosition));
            }
        }
    }
}
