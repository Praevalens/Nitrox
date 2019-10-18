using NitroxClient.Communication.Abstract;
using NitroxClient.GameLogic.Helper;
using NitroxClient.MonoBehaviours;
using NitroxModel.DataStructures;
using NitroxModel.DataStructures.Util;
using NitroxModel.Logger;
using NitroxModel.Packets;
using NitroxModel_Subnautica.Helper;
using UnityEngine;

namespace NitroxClient.GameLogic
{
    public class DeployableItem : Item
    {

        public DeployableItem(IPacketSender packetSender) : base(packetSender)
        {

        }

        public void Deploy(GameObject gameObject, Vector3 deployPosition)
        {
            NitroxId id = NitroxIdentifier.GetId(gameObject);
            byte[] bytes = SerializationHelper.GetBytes(gameObject);

            Log.Debug("Deployed item with id: " + id);

            DeployItem deployedItem = new DeployItem(id, deployPosition, bytes);
            packetSender.Send(deployedItem);
        }

    }
}
