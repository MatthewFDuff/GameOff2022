using System;
using Core.Modules;
using Core.Modules.Recipes;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    public void UpdateLevelInfo(Level level)
    {
        label.text = $"{level.name}: {level.GetRecipe(0).recipeName}";
    }
}
