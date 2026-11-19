using UnityEngine;

namespace TalosNPC.UnityToolkit.Demos
{
    [AddComponentMenu("Talos NPC/Demos/DestroyVehicles")]

    public class DestroyVehicles : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Car")
            {
                Destroy(other.gameObject);
            }
        }
    }
}