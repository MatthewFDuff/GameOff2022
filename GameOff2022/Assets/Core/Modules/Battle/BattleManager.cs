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
        public static event Action<Recipe> OnRecipeAdded;
        public UnityEvent onGameOver;
        public UnityEvent onLevelComplete;
        public UnityEvent OnGameCompleted;

        List<RuntimeEnemy> activeEnemies;
        int recipesCompleted = 0;
        Timer levelTimer;
        GameManager manager;

        void Awake()
        {
            activeEnemies = new List<RuntimeEnemy>();
            manager = FindObjectOfType<GameManager>();
            currentLevel = manager.GetNextLevel();
        }

        void Start()
        {
            if (!startBattleOnStart) return;
            if (currentLevel is null)
            {
                Debug.LogWarning("No Level set", this);
                OnGameCompleted?.Invoke();
                return;
            }
            
            FindObjectOfType<LevelUI>().UpdateLevelInfo(currentLevel);
            StartBattle();
        }

        public void SetLevel(Level newLevel) => currentLevel = newLevel;

        public Recipe CurrentRecipe;

        public void StartBattle()
        {
            recipesCompleted = 0;

            StartLevelTimer();
            SpawnNextRecipe();
        }

        void SpawnNextRecipe()
        {
            var nextRecipe = currentLevel.GetRecipe(recipesCompleted);
            if (nextRecipe == null)
            {
                LevelComplete();
            }
            else
            {
                SpawnRecipe(currentLevel.GetRecipe(recipesCompleted));
            }
        }

        public void LevelComplete()
        {
            OnRecipeAdded?.Invoke(currentLevel.GetRecipe(recipesCompleted));
            manager.CompleteLevel();
            onLevelComplete?.Invoke();
        }

        public void GameOver()
        {
            onGameOver?.Invoke();
        }

        public void SpawnRecipe(Recipe recipe)
        {
            CurrentRecipe = recipe;
            var bucketOfSpawns = new Bucket<Transform>(new List<Transform>(enemySpawnLocations));
            foreach (var enemy in recipe.GetEnemies())
            {
                SpawnEnemyAt(enemy, bucketOfSpawns.GetItem());
            }
        }

        public void RemoveEnemy(RuntimeEnemy enemy)
        {
            activeEnemies.Remove(enemy);
            if (activeEnemies.Count != 0) return;
            
            recipesCompleted++;
            SpawnNextRecipe();
        }

        static void SpawnEnemyAt(Enemy enemy, Transform spawnPoint)
        {
            Instantiate(enemy.EnemyPrefab, spawnPoint.position, Quaternion.identity);
        }

        void StartLevelTimer()
        {
            levelTimer?.Stop();
            levelTimer = new Timer(this, currentLevel.GetDuration(), 0.1f);
            levelTimer.OnCompleted += GameOver;
            levelTimer.OnTick += (elapsedTime) => timerTick?.Invoke(currentLevel.GetDuration() - elapsedTime);
            levelTimer.Start();
        }

        public void AddEnemy(RuntimeEnemy runtimeEnemy)
        {
            activeEnemies.Add(runtimeEnemy);
        }
    }
}