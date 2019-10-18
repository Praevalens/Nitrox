using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NitroxClient.GameLogic.Helper
{
    public class ItemDeployingGUIHand : GUIHand
    {
        public Vector3 deployedPosition { get; set; }


        public ItemDeployingGUIHand(Vector3 deployedPosition) : base()
        {
            this.deployedPosition = deployedPosition;
        }
    }
}
