using System;
using Core.Modules.Controls;
using UnityEngine;

namespace Core.Scripts
{
    public class MoveTowardsPlayer : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float targetOffset;
        Transform target;
        
        void Start()
        {
            target = FindObjectOfType<PlayerController>().transform;
        }

        void FixedUpdate()
        {
            if (transform.position.x > target.position.x)
            {
                var moveTowards = target.position + new Vector3(targetOffset, 0, 0);
                MoveTowards(moveTowards);  
            }
            else
            {
                var moveTowards = target.position + new Vector3(-targetOffset, 0, 0);
                MoveTowards(moveTowards);
            }
        }

        void MoveTowards(Vector3 pointToMoveTowards)
        {
            var direction = (pointToMoveTowards - transform.position).normalized;
            rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));  
        }
    }
}