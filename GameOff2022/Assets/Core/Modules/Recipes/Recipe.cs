using Core.Scripts;
using UnityEngine;

namespace Core.Modules.Recipes
{
    [CreateAssetMenu(fileName = "newRecipe", menuName = "Scriptables/Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [SerializeField] Ingredient[] ingredients;
    }
}