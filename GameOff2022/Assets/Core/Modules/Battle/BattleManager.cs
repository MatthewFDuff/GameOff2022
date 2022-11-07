using Core.Modules.Recipes;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Modules.Battle
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] bool startBattleOnStart;

        public Recipe currentRecipe => currentRecipeWavePair.GetRecipe();
        
        public UnityEvent<Recipe> recipeChanged;
        public UnityEvent<float> timerTick;

        int recipesCompleted = 0;
        int wavesCompleted = 0;
        
        RecipeWavesPair currentRecipeWavePair;
        Level currentLevel;
        Timer levelTimer;

        void Start()
        {
            if(startBattleOnStart) StartBattle();
        }

        public void StartBattle()
        {
            recipesCompleted = 0;
            wavesCompleted = 0;
            
            SetNextRecipe();
            StartLevelTimer();
            SpawnNextWave();
        }
        
        public void StopBattle()
        {
            // Don't know the logic for this quite yet
        }

        public void SpawnNextWave()
        {
            var wave = currentLevel.GetWave(recipesCompleted, wavesCompleted);
            foreach (var enemy in wave.EnemiesInWave)
            {
                // Get spawn point and instantiate enemy there
            }
        }

        void SetNextRecipe()
        {
            currentRecipeWavePair = currentLevel.GetNextRecipeWave();
            recipeChanged?.Invoke(currentRecipeWavePair.GetRecipe());
        }

        void StartLevelTimer()
        {
            levelTimer = new Timer(this, currentLevel.GetLevelDuration(), 0.1f);
            levelTimer.OnCompleted += StopBattle;
            levelTimer.OnTick += (elapsedTime) => timerTick?.Invoke(elapsedTime);
            levelTimer.Start();
        }
    }
}