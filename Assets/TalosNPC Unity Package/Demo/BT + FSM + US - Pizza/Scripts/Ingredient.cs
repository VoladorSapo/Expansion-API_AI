using UnityEngine;

namespace TalosNPC.UnityToolkit.Demos
{
    [CreateAssetMenu(menuName = "TalosNPC/Demos/Pizza/Ingredient", fileName = "ingredient")]

    [AddComponentMenu("Talos NPC/Demos/Ingredient")]

    public class Ingredient : ScriptableObject
    {
        public string Name;
        public GameObject prefab;
        public float height = .01f;
    }

}