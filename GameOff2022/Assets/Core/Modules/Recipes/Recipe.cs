using System.Collections.Generic;
using System.Linq;
using Core.Scripts;
using UnityEngine;

namespace Core.Modules.Recipes
{
    [CreateAssetMenu(fileName = "newRecipe", menuName = "Scriptables/Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [SerializeField] Enemy[] enemies;
        public Sprite pic;

        public Enemy[] GetEnemies() => enemies;

        public string recipeName;
        public string recipeType;

    } 
}