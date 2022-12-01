using System;
using System.Collections;
using System.Collections.Generic;
using Core.Modules.Battle;
using Core.Modules.Recipes;
using UnityEngine;
using UnityEngine.UI;

public class CompleteScreen : MonoBehaviour
{
    [SerializeField] Image img;

    private void Start()
    {
        SetScreen();
    }

    public void SetScreen()
    {
        // Debug.Log($"Recipe: { recipe.recipeName}");
        img.sprite = FindObjectOfType<BattleManager>().CurrentRecipe.pic;
    }
}
