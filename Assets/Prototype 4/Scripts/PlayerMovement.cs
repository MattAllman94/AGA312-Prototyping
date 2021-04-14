using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
    public class PlayerMovement : JMC
    {
        float translation, straffe;
        public float speed;

        public float lookSpeed = 3;
        Vector2 rotation = Vector2.zero;
        void Start()
        {

        }


        void Update()
        {
            Movement();
            Look();
        }

        void Movement()
        {
            translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            straffe = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(translation, 0, straffe);
        }

        void Look()
        {
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
            transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
            Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
        }
    }
}



