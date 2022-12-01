using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    
    private void Start()
    {
        ScoreManager.OnScoreUpdated += UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        scoreLabel.text = newScore.ToString(format:"00000000");
    }
}
