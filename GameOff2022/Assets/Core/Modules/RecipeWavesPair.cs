using System;
using Core.Modules.Recipes;
using Core.Scripts;
using UnityEngine;

namespace Core.Modules
{
    // A pairing of a set of enemy waves and a recipe. This allows us to have different wave structures per recipe.
    [Serializable]
    public class RecipeWavesPair
    {
        [SerializeField] Recipe recipe;
        [SerializeField] Wave[] waves;

        public Recipe GetRecipe() => recipe;

        public Wave GetWave(int i)
        {
            if (i >= waves.Length || i < 0) return null;
            return waves[i];
        }
    }
}