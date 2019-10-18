using System;
using System.Reflection;
using Harmony;
using NitroxClient.GameLogic;
using NitroxClient.GameLogic.Helper;
using NitroxModel.Core;
using UnityEngine;

namespace NitroxPatcher.Patches
{
    public class PipeSurfaceFloater_OnToolUseAnim_Patch : NitroxPatch
    {
        public static readonly Type TARGET_CLASS = typeof(PipeSurfaceFloater);
        public static readonly MethodInfo TARGET_METHOD = TARGET_CLASS.GetMethod("OnToolUseAnim", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(GUIHand) }, null);

        // If the guiHand object is null that means the function was called by the packet processor,
        // therefore we should not play the animation of deploying the item rather just deploying it without playing any animations.
        public static bool Prefix(ref PipeSurfaceFloater __instance, GUIHand guiHand)
        {
            if (guiHand.GetType() == typeof(ItemDeployingGUIHand))
            {
                Traverse.Create(__instance).Field("scale").SetValue(0f);
                __instance.transform.position = ((ItemDeployingGUIHand)guiHand).deployedPosition;
                __instance.deployed = true;

                return false;
            }

            return true;
        }

        public static void Postfix(PipeSurfaceFloater __instance, GUIHand guiHand)
        {

            // Check if we were on the receiving end of a deployment
            if (guiHand.GetType() != typeof(ItemDeployingGUIHand))
            {
                // It was a players GUIHand
                // Broadcast to other clients this pump is deployed
                NitroxServiceLocator.LocateService<DeployableItem>().Deploy(__instance.GetGameObject(), __instance.transform.position);
            }
            
        }

        public override void Patch(HarmonyInstance harmony)
        {
            PatchPostfix(harmony, TARGET_METHOD);
        }
    }
}

