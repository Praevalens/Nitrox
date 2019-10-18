using System;
using NitroxModel.DataStructures.Util;
using UnityEngine;
using NitroxModel.DataStructures;

namespace NitroxModel.Packets
{
    [Serializable]
    public class DeployItem : Packet
    {
        public NitroxId Id { get; }
        public Vector3 DeployPosition { get; }
        public byte[] Bytes { get; }

        public DeployItem(NitroxId id, Vector3 deployPosition, byte[] bytes)
        {
            Id = id;
            DeployPosition = deployPosition;
            Bytes = bytes;
        }        

        public override string ToString()
        {
            return "[DeployedItem - id: " + Id + " itemPosition: " + DeployPosition + "]";
        }
    }
}
