using System.Collections.Generic;
using UnityEngine;

namespace TalosNPC.UnityToolkit
{
    [CreateAssetMenu(fileName = "NewAgentSettings", menuName = "TalosNPC/Smart Objects/Agent Settings")]
    public class SmartAgentSettings : ScriptableObject
    {
        [Header("Needs")]
        [SerializeField] NeedMap _needMap;

        public Dictionary<string, float> GetCapabilityMap() => new Dictionary<string, float>(_needMap);
    }
}
