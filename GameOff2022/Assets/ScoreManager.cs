using System;
using Core.Modules.Utility.Singletons;
using Core.Scripts;
using UnityEngine;

public class ScoreManager : PersistentSingleton<ScoreManager>
{
    [SerializeField] private int playerScore;
    
    public int CurrentScore => playerScore;

    public static event Action<int> OnScoreUpdated;

    protected override void Awake()
    {
        RuntimeEnemy.OnEnemyDeath += AddToScore;
    }

    private void Start()
    {
        playerScore = 0;
    }
    
    public void AddToScore(int valueToAdd)
    {
        playerScore += valueToAdd;
        
        OnScoreUpdated?.Invoke(playerScore);
    }
}
