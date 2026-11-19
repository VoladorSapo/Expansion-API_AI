namespace TalosNPC.UnityToolkit.Demos
{
	using UnityEngine;
    [AddComponentMenu("Talos NPC/Demos/DestroyEffect")]

    public class DestroyEffect : MonoBehaviour
	{

		void Update()
		{

			if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
				Destroy(transform.gameObject);

		}
	}
}
