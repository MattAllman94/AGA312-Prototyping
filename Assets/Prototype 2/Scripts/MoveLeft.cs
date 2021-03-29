using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype2
{
    public class MoveLeft : JMC
    {

        public float speed = 0.5f;
        private float leftBound = -15;


        void Start()
        {

        }
        void Update()
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);

            if (transform.position.x < leftBound)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Root"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
