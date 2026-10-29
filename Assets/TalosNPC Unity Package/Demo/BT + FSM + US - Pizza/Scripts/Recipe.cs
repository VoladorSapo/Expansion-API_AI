using System.Collections.Generic;
using UnityEngine;

namespace TalosNPC.UnityToolkit.Demos
{
	[CreateAssetMenu(menuName = "TalosNPC/Demos/Pizza/Recipe", fileName = "recipe")]
	public class Recipe : ScriptableObject
	{
		public string RecipeName;
		public List<Ingredient> ingredients;
	}

}