using Core.Modules.Battle;
using UnityEngine;

namespace Core.Modules
{
    [CreateAssetMenu(fileName = "newIngredient", menuName = "Scriptables/Level", order = 0)]
    public class Level : ScriptableObject
    {
        [SerializeField] float durationInSeconds;  
        [SerializeField] Customer[] customers;

        public float GetDuration() => durationInSeconds;
        public Customer[] GetCustomers() => customers;
    }
}