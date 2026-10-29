using TalosNPC.Core;
using TalosNPC.Core.Actions;
using TalosNPC.SmartObjects;
using TalosNPC.UnityToolkit;
using UnityEngine;

namespace TalosNPC.UnityToolkit.Demos
{
    public class ShowerSmartObject : DirectSmartObject
    {
        [SerializeField] Transform _useTransform;
        [SerializeField] ParticleSystem _particleSystem;

        [SerializeField] float useTime = 5f;

        NPCPoseController _poseController;

        float lieTime;

        protected override Action GetUseAction(SmartAgent agent, RequestData requestData)
        {
            return new FunctionalAction(() => StartUse(agent), Wait, () => StopUse(agent));
        }

        void StartUse(SmartAgent smartAgent)
        {
            lieTime = Time.time;
            _poseController = smartAgent.GetComponent<NPCPoseController>();
            smartAgent.transform.SetPositionAndRotation(_useTransform.position, _useTransform.rotation);
            _poseController.ChangeToStaticPose();
            _particleSystem.Play();
        }

        void StopUse(SmartAgent smartAgent)
        {
            if (_placeTarget == null) return;

            smartAgent.transform.SetLocalPositionAndRotation(_placeTarget.position, _placeTarget.rotation);
            _poseController.ChangeToReleasePose();
            _particleSystem.Stop();
        }

        Status Wait()
        {
            if (Time.time > lieTime + useTime)
            {
                return Status.Success;
            }
            return Status.Running;
        }
    }
}
