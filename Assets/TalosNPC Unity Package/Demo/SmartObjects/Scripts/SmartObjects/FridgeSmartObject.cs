using TalosNPC.Core;
using TalosNPC.Core.Actions;
using TalosNPC.UnityToolkit.Demos;
using UnityEngine;
using TalosNPC.SmartObjects;
using System.Collections.Generic;

namespace TalosNPC.UnityToolkit.Demos
{
    [AddComponentMenu("Talos NPC/Demos/FridgeSmartObject")]

    public class FridgeSmartObject : DirectSmartObject
    {
        [SerializeField] float useTime = 3f;
        [SerializeField] Transform fridgeDoor;
        float lieTime;

        protected override Action GetUseAction(SmartAgent agent, RequestData requestData)
        {
            return new FunctionalAction(StartUse, () => OnUpdate(agent), StopUse);
        }

        void StartUse()
        {
            lieTime = Time.time;
            fridgeDoor.rotation = Quaternion.Euler(0, -90, 0);
        }

        void StopUse()
        {
            fridgeDoor.rotation = Quaternion.identity;
        }

        Status OnUpdate(SmartAgent smartAgent)
        {
            if (Time.time > lieTime + useTime)
            {
                return Status.Success;
            }
            return Status.Running;
        }

        public override float GetCapabilityValue(string capabilityName)
        {
            return 0f;
        }
    }
}

