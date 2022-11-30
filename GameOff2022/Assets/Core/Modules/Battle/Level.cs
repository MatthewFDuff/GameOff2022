using Core.Modules.Recipes;
using UnityEngine;

namespace Core.Modules
{
    [CreateAssetMenu(fileName = "newLevel", menuName = "Scriptables/Level", order = 0)]
    public class Level : ScriptableObject
    {
        [SerializeField] float durationInSeconds;  
        [SerializeField] Recipe[] recipes;

        public float GetDuration() => durationInSeconds;
        public Recipe GetRecipe(int i) => recipes[i];
    }
}