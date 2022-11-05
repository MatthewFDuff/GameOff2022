using System;
using UnityEngine;

namespace Core.Modules.UI
{
    [RequireComponent(typeof(Canvas))]
    public abstract class UIView : MonoBehaviour
    {
        /// <summary>
        /// Used to check if the UI has already been initialized during UIManager setup.
        /// </summary>
        protected bool IsInitialized { get; set; }

        [SerializeField] public Canvas canvas;
        [SerializeField] internal bool isPersistent;
        [SerializeField] private bool isActiveAtStart;
        [SerializeField] private UIAnimation showAnimation;
        [SerializeField] private UIAnimation hideAnimation;

        public virtual void Initialize()
        {
            canvas ??= GetComponent<Canvas>();
            canvas.enabled = isActiveAtStart || isPersistent;

            IsInitialized = true;
        }

        public virtual void Show()
        {
            DisplayCanvas(true);

            if (showAnimation)
            {
                showAnimation.Play();
            }
        }

        public virtual void Hide()
        {
            if (hideAnimation)
            {
                hideAnimation.Play(DisplayCanvas(false));
            }
            else
            {
                DisplayCanvas(false);
            }
        }

        public Action DisplayCanvas(bool isDisplayed)
        {
            if (canvas == null) return null;
            
            canvas.enabled = isDisplayed;

            return null;
        }
    }
}