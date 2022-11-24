using UnityEngine;

namespace Core.Modules.Recipes
{
    public class InGameIngredient : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        Ingredient ingredient;

        public void SetIngredient(Ingredient newIngredient)
        {
            ingredient = newIngredient;
            spriteRenderer.sprite = ingredient.sprite;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
      
        }
    }
}