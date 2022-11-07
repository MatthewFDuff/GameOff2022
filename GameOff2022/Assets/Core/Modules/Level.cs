using Core.Modules.Recipes;
using Core.Scripts;
using UnityEngine;

namespace Core.Modules
{
    [CreateAssetMenu(fileName = "newIngredient", menuName = "Scriptables/Level", order = 0)]
    public class Level : ScriptableObject
    {
        [SerializeField] float levelDuration;
        [SerializeField] RecipeWavesPair[] recipeWaves;

        public RecipeWavesPair GetNextRecipeWave()
        {
            // How do we want to determine next recipes? In order? Infinite? Random?
            var randomNum = Random.Range(0, recipeWaves.Length);
            return recipeWaves[randomNum];
        }

        public Wave GetWave(int recipesCompleted, int wavesCompleted)
        {
            if (recipesCompleted >= recipeWaves.Length || recipesCompleted < 0) return null;
            return recipeWaves[recipesCompleted].GetWave(wavesCompleted);
        }

        public float GetLevelDuration() => levelDuration;
    }
}