using System;
using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    [Serializable]
    public class MovementState : PlayerState
    {
        public float speed;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        Vector3 movementVec;
        public override void OnUpdate(PlayerController controller)
        {
            if (controller.data is null)
            {
                Debug.LogError("Movement State needs data");
                return;
            }
            
            var horizontalMovement = Input.GetAxis("Horizontal");
            var verticalMovement = 0.6f * Input.GetAxis("Vertical");

            movementVec = new Vector3(horizontalMovement, verticalMovement, 0);
            if (movementVec.magnitude > 1) movementVec = movementVec.normalized;
            
            controller.data.PlayerAnimator?.SetBool(IsWalking, movementVec.magnitude > 0);
            
            SetRotation(controller, horizontalMovement);
        }

        public override void OnFixedUpdate(PlayerController controller)
        {
            base.OnStateExit(controller);
            
            controller.data.playerBody.MovePosition(controller.data.transform.position + movementVec * speed * Time.fixedDeltaTime);
        }

        static void SetRotation(PlayerController controller, float horizontalMovement)
        {
            if (horizontalMovement > 0)
            {
                controller.data.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (horizontalMovement < 0)
            {
                controller.data.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}