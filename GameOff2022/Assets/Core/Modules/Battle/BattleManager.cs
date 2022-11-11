using System;
using System.Collections.Generic;
using Core.Modules.Recipes;
using Core.Modules.Utility;
using Core.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Modules.Battle
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] bool startBattleOnStart;
        [SerializeField] Transform[] enemySpawnLocations;
        
        public UnityEvent<float> timerTick;
        public UnityEvent<Recipe> recipeAdded;

        List<Recipe> activeRecipes;
        List<Ingredient> collectedIngredients;
        int recipesCompleted = 0;
        Level currentLevel;
        Timer levelTimer;

        void Awake()
        {
            activeRecipes = new List<Recipe>();
            collectedIngredients = new List<Ingredient>();
        }

        void Start()
        {
            if (!startBattleOnStart) return;
            if (currentLevel is null)
            {
                Debug.LogWarning("No Level set", this);
                return;
            }
            StartBattle();
        }

        public void SetLevel(Level newLevel) => currentLevel = newLevel;

        public void StartBattle()
        {
            recipesCompleted = 0;

            StartLevelTimer();
        }
        
        public void StopBattle()
        {
            // Don't know the logic for this quite yet
        }
        
        public void AddRecipe(Recipe recipe)
        {
            activeRecipes.Add(recipe);
            SpawnRecipe(recipe);
            recipeAdded?.Invoke(recipe);
        }

        public void SpawnRecipe(Recipe recipe)
        {
            var bucketOfSpawns = new Bucket<Transform>(new List<Transform>(enemySpawnLocations));
            foreach (var enemy in recipe.GetEnemies())
            {
                SpawnEnemyAt(enemy, bucketOfSpawns.GetItem());
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            collectedIngredients.Add(ingredient);

            var currentRecipe = activeRecipes[0];
            if (currentRecipe is null || !currentRecipe.CanCompleteRecipe(collectedIngredients)) return;

            CompleteRecipe(currentRecipe);
        }

        void CompleteRecipe(Recipe recipeToComplete)
        {
            if (!activeRecipes.Contains(recipeToComplete)) return;
            activeRecipes.Remove(recipeToComplete);

            foreach (var ingredient in recipeToComplete.GetIngredients())
            {
                if (!collectedIngredients.Remove(ingredient))
                {
                    Debug.LogWarning("Failed to remove ingredient when completing recipe");
                }
            }

            recipesCompleted++;
        }

        static void SpawnEnemyAt(Enemy enemy, Transform spawnPoint)
        {
            Instantiate(enemy.EnemyPrefab, spawnPoint.position, Quaternion.identity);
        }

        void StartLevelTimer()
        {
            levelTimer = new Timer(this, currentLevel.GetDuration(), 0.1f);
            levelTimer.OnCompleted += StopBattle;
            levelTimer.OnTick += (elapsedTime) => timerTick?.Invoke(elapsedTime);
            levelTimer.Start();
        }
    }
}