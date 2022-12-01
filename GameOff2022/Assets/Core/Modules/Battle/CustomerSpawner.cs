using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Modules.Battle
{
    public class CustomerSpawner : MonoBehaviour
    {
        public Customer customerObj;

        public List<GameObject> Line;

        public Transform target;

        private float speed = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            Line.Add(Instantiate(customerObj.customerGO, gameObject.transform.position, Quaternion.identity, transform));
        }

        // Update is called once per frame
        void Update()
        {
            MoveCustomer();
        }

        private void MoveCustomer()
        {
            for(int x = 0; x < Line.Count; x++)
            {
                if(Line[x].transform.position.x < target.position.x)
                {
                    Line[x].transform.position += new Vector3(target.position.x,0.0f);
                }      
            }  
        }
    }
}