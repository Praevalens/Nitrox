﻿using NitroxServer.GameLogic;
using NitroxServer.GameLogic.Bases;
using NitroxServer.GameLogic.Entities;
using NitroxServer.GameLogic.Items;
using NitroxServer.GameLogic.Players;
using NitroxServer.GameLogic.Vehicles;
using ProtoBufNet;
using System;
using System.Collections.Generic;
using NitroxModel.Logger;
using NitroxModel.DataStructures;

namespace NitroxServer.Serialization.World
{
    [ProtoContract]
    public class PersistedWorldData
    {
        private const long CURRENT_VERSION = 10;

        [ProtoMember(1)]
        public long version { get; set; } = CURRENT_VERSION;

        [ProtoMember(2)]
        public List<Int3> ParsedBatchCells { get; set; }
        
        [ProtoMember(3)]
        public DateTime ServerStartTime { get; set; }
        
        [ProtoMember(4)]
        public EntityData EntityData { get; set; }

        [ProtoMember(5)]
        public BaseData BaseData { get; set; }

        [ProtoMember(6)]
        public VehicleData VehicleData { get; set; }

        [ProtoMember(7)]
        public InventoryData InventoryData { get; set; }

        [ProtoMember(8)]
        public PlayerData PlayerData { get; set; }

        [ProtoMember(9)]
        public GameData GameData { get; set; }

        [ProtoMember(10)]
        public EscapePodData EscapePodData { get; set; }

        public bool IsValid()
        {
            if(version < CURRENT_VERSION)
            {
                Log.Error("Version " + version + " save file is no longer supported.  Creating world under version " + CURRENT_VERSION);
                return false;
            }

            Log.Error("" + (ParsedBatchCells != null));
            Log.Error("" + (ServerStartTime != null));
            Log.Error("" + (BaseData != null));
            Log.Error("" + (VehicleData != null));
            Log.Error("" + (InventoryData != null));
            Log.Error("" + (GameData != null));
            Log.Error("" + (PlayerData != null));
            Log.Error("" + (EntityData != null));
            Log.Error("" + (EntityData.SerializableEntitiesById.Count > 0));
            Log.Error("" + (EscapePodData != null));

            return (ParsedBatchCells != null) &&
                   (ServerStartTime != null) &&
                   (BaseData != null) &&
                   (VehicleData != null) &&
                   (InventoryData != null) &&
                   (GameData != null) &&
                   (PlayerData != null) &&
                   (EntityData != null) &&
                   (EntityData.SerializableEntitiesById.Count > 0) &&
                   (EscapePodData != null);
        }
    }
}
