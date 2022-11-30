using UnityEngine;

namespace Core.Modules.Recipes
{
    [CreateAssetMenu(fileName = "newIngredient", menuName = "Scriptables/Ingredient", order = 0)]
    public class Ingredient : ScriptableObject
    {
        [SerializeField] Sprite Sprite;
        public Sprite sprite => Sprite;
    }
}