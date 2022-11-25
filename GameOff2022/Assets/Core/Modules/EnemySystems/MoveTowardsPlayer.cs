using System;
using Core.Modules.Controls;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Scripts
{
    public class MoveTowardsPlayer : MonoBehaviour
    {
        public UnityEvent atTarget;
        [SerializeField] float speed;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float targetOffset;
        [SerializeField] float tolerance;
        Transform target;
        
        void Start()
        {
            target = FindObjectOfType<PlayerController>().transform;
        }

        void FixedUpdate()
        {
            if (transform.position.x > target.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                var moveTowards = target.position + new Vector3(targetOffset, 0, 0);
                MoveTowards(moveTowards);  
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                var moveTowards = target.position + new Vector3(-targetOffset, 0, 0);
                MoveTowards(moveTowards);
            }
        }

        void MoveTowards(Vector3 pointToMoveTowards)
        {
            if (IsInRange(pointToMoveTowards))
            {
                atTarget?.Invoke();
                return;
            }
            var direction = (pointToMoveTowards - transform.position).normalized;
            rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));  
        }

        bool IsInRange(Vector3 pointToMoveTowards)
        {
            return Vector3.Distance(transform.position, pointToMoveTowards) <= tolerance;
        }
    }
}