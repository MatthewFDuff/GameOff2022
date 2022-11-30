using System.Collections;
using System.Collections.Generic;
using Core.Modules.Recipes;
using UnityEngine;
using UnityEngine.UI;

public class CompleteScreen : MonoBehaviour
{
    [SerializeField] Image img;

    public void SetScreen(Recipe recipe)
    {
        img.sprite = recipe.pic;
    }
}
