using UnityEngine;

namespace TalosNPC.UnityToolkit.Demos
{
    [CreateAssetMenu(menuName = "TalosNPC/Demos/Pizza/Ingredient", fileName = "ingredient")]

    public class Ingredient : ScriptableObject
    {
        public string Name;
        public GameObject prefab;
        public float height = .01f;
    }

}