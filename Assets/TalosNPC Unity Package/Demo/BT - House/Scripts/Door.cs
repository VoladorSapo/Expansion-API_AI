using UnityEngine;
using UnityEngine.UI;

namespace TalosNPC.UnityToolkit.Demos
{
    [AddComponentMenu("Talos NPC/Demos/Door")]

    public class Door : MonoBehaviour
    {
        [SerializeField] Toggle toggle;
        public bool IsClosed { get; set; }

        private void Start()
        {
            IsClosed = toggle.isOn;
        }

        public void OnReset()
        {
            IsClosed = toggle.isOn;
        }
    }

}