using System;
using Core.Modules.Recipes;
using UnityEngine;

namespace Core.Modules.Battle
{
    // Each customer has a recipe and time they're willing to wait to receive it.
    [Serializable]
    public class Customer
    {
        public GameObject customerGO => customerPrefab;
        public Recipe recipeWanted => requestedRecipe;
        public bool isWaiting => waitTimer.IsActive;

        public event Action TimeWillingToWaitExceeded;
        
        [SerializeField] GameObject customerPrefab;
        [SerializeField] Recipe requestedRecipe;
        [SerializeField] float arrivalTime;
        [SerializeField] float timeWillingToWait;
        
        Timer waitTimer;

        public void StartWaiting(MonoBehaviour boundBehaviour, Action<float> onTickCallback)
        {
            if(waitTimer is null || waitTimer.IsActive) return;
            
            waitTimer = new Timer(boundBehaviour, timeWillingToWait, 0.1f);
            waitTimer.OnCompleted += () => TimeWillingToWaitExceeded?.Invoke();
            waitTimer.OnTick += onTickCallback;
            waitTimer.Start();
        }
    }
}