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
        [SerializeField] Level currentLevel;

        public UnityEvent<float> timerTick;
        public UnityEvent<Recipe> recipeAdded;

        int activeEnemies;
        int recipesCompleted = 0;
        Timer levelTimer;


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
            SpawnNextRecipe();
        }

        void SpawnNextRecipe()
        {
            SpawnRecipe(currentLevel.GetRecipe(recipesCompleted));
        }

        public void StopBattle()
        {
            // Don't know the logic for this quite yet
        }
        

        public void SpawnRecipe(Recipe recipe)
        {
            var bucketOfSpawns = new Bucket<Transform>(new List<Transform>(enemySpawnLocations));
            foreach (var enemy in recipe.GetEnemies())
            {
                SpawnEnemyAt(enemy, bucketOfSpawns.GetItem());
            }
        }

        public void ReportEnemyDefeated()
        {
            activeEnemies--;
            if (activeEnemies != 0) return;

            recipesCompleted++;
            SpawnNextRecipe();
        }

        void SpawnEnemyAt(Enemy enemy, Transform spawnPoint)
        {
            Instantiate(enemy.EnemyPrefab, spawnPoint.position, Quaternion.identity);
            activeEnemies++;
        }

        void StartLevelTimer()
        {
            levelTimer?.Stop();
            levelTimer = new Timer(this, currentLevel.GetDuration(), 0.1f);
            levelTimer.OnCompleted += StopBattle;
            levelTimer.OnTick += (elapsedTime) => timerTick?.Invoke(currentLevel.GetDuration() - elapsedTime);
            levelTimer.Start();
        }
    }
}