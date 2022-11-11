using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Modules.Utility.Extensions
{
    public static class ButtonExtensions
    {
        public static void AddOnClickListener(this Button button, UnityAction action)
        {
            if (button == null)
            {
                Debug.LogError("Failed to add on click listener to button that is null.");
                return;
            }
            
            button.onClick.AddListener(action);
        }
    }
}