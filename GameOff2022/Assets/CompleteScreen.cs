using Core.Modules.Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompleteScreen : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] private TextMeshProUGUI sandwichName;
    private void Start()
    {
        SetScreen();
    }

    public void SetScreen()
    {
        // Debug.Log($"Recipe: { recipe.recipeName}");
        img.sprite = FindObjectOfType<BattleManager>().CurrentRecipe.pic;
        sandwichName.text = FindObjectOfType<BattleManager>().CurrentRecipe.recipeName;
    }
}
