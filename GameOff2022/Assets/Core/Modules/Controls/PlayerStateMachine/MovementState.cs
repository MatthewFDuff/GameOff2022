﻿using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    public class MovementState : PlayerState
    {
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        public override void OnUpdate(PlayerStateMachineData data = null)
        {
            if (data is null)
            {
                Debug.LogError("Movement State needs data");
                return;
            }
            var horizontalMovement = Input.GetAxis("Horizontal");
            var verticalMovement = Input.GetAxis("Vertical");

            var effectiveSpeed = data.Speed * Time.deltaTime;
            var movementVec = new Vector3(horizontalMovement, verticalMovement, 0);
            if (movementVec.magnitude > 1) movementVec = movementVec.normalized;


            data.PlayerAnimator?.SetBool(IsWalking, movementVec.magnitude > 0);
            
            
            data.transform.position += movementVec * effectiveSpeed;
        }
    }
}