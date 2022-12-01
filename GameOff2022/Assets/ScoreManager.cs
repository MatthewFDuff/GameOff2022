using System;
using Core.Modules.Utility.Singletons;
using UnityEngine;

public class ScoreManager : PersistentSingleton<ScoreManager>
{
    [SerializeField] private int playerScore;
    
    public int CurrentScore => playerScore;

    public event Action<int> OnScoreUpdated; 

    private void Start()
    {
        playerScore = 0;
    }
    
    public void AddToScore(int valueToAdd)
    {
        playerScore = valueToAdd;
        
        OnScoreUpdated?.Invoke(playerScore);
    }
}
