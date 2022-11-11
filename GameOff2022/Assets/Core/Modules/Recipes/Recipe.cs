using System.Collections.Generic;
using System.Linq;
using Core.Scripts;
using UnityEngine;

namespace Core.Modules.Recipes
{
    [CreateAssetMenu(fileName = "newRecipe", menuName = "Scriptables/Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [SerializeField] Ingredient[] ingredients;
        [SerializeField] Enemy[] enemies;

        public Enemy[] GetEnemies() => enemies;
        public Ingredient[] GetIngredients() => ingredients;

        public bool CanCompleteRecipe(List<Ingredient> ingredientsProvided)
        {
            return ingredients.All(ingredientsProvided.Contains);
        }
    }
}