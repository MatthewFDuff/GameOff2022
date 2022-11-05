using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Core.Modules.UI
{
    public class UIAnimation : MonoBehaviour
    {
        /// <summary>
        /// Animation settings.
        /// </summary>
        [SerializeField] internal Transform target;
        [SerializeField] internal float duration;
        [SerializeField] internal Ease ease;

        /// <summary>
        /// Scale
        /// </summary>
        [SerializeField] internal Vector3 initialScale;
        [SerializeField] internal Vector3 targetScale;
        
        /// <summary>
        /// Position
        /// </summary>
        [SerializeField] internal Vector3 initialPosition;
        [SerializeField] internal Vector3 targetPosition;
        
        /// <summary>
        /// Rotation
        /// </summary>
        [SerializeField] internal Quaternion initialRotation;
        [SerializeField] internal Quaternion targetRotation;

        private void Awake()
        {
            target ??= transform;
        }

        public void Play(Action callback = null)
        {
            StartTween();
            StartCoroutine(StartAnimationTimer(callback));
        }

        private IEnumerator StartAnimationTimer(Action callback = null)
        {
            yield return new WaitForSeconds(duration);
            
            callback?.Invoke();
        }

        protected virtual void StartTween()
        {
            target.localScale = initialScale;
            target.localPosition = initialPosition;
            target.localRotation = initialRotation;

            target.DOScale(targetScale, duration).SetEase(ease);
            target.DORotateQuaternion(targetRotation, duration).SetEase(ease);
            target.DOMove(targetPosition, duration).SetEase(ease);
        }
    }
}