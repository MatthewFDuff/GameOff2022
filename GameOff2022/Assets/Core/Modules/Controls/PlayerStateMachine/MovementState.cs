using System;
using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    [Serializable]
    public class MovementState : PlayerState
    {
        public float speed;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        public override void OnUpdate(PlayerController controller)
        {
            if (controller.data is null)
            {
                Debug.LogError("Movement State needs data");
                return;
            }
            var horizontalMovement = Input.GetAxis("Horizontal");
            var verticalMovement = Input.GetAxis("Vertical");

            var effectiveSpeed = speed * Time.deltaTime;
            var movementVec = new Vector3(horizontalMovement, verticalMovement, 0);
            if (movementVec.magnitude > 1) movementVec = movementVec.normalized;
            
            controller.data.PlayerAnimator?.SetBool(IsWalking, movementVec.magnitude > 0);
            
            
            controller.data.transform.position += movementVec * effectiveSpeed;
        }
    }
}