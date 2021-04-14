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

        public Transform holdPos;
        public GameObject vial;
        bool isHeld;

        void Start()
        {

        }


        void Update()
        {
            Movement();
            Look();
            Interact();
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

        void Interact()
        {
            Vector3 origin = Camera.main.transform.position;
            Vector3 direction = Camera.main.transform.forward;
            float distance = 3f;
            RaycastHit hit;

            if(Physics.Raycast(origin, direction, out hit, distance))
            {
                if (hit.collider.CompareTag("Vial"))
                {
                    Debug.Log(hit);

                    if (Input.GetKeyDown(KeyCode.E) && isHeld == false)
                    {
                        vial = hit.collider.gameObject;
                        vial.transform.position = holdPos.position;
                        vial.transform.rotation = holdPos.rotation;
                        vial.transform.SetParent(holdPos);
                        vial.GetComponent<CapsuleCollider>().enabled = false;
                        vial.GetComponent<Rigidbody>().isKinematic = true;
                        isHeld = true;
                    }
                    else
                    {
                        isHeld = false;
                    }
                }
            }

            if(Input.GetKeyDown(KeyCode.Q) && isHeld == true)
            {
                vial.transform.SetParent(null);
                vial.GetComponent<CapsuleCollider>().enabled = true;
                vial.GetComponent<Rigidbody>().isKinematic = false;
                vial = null;

            }


        }
    }
}



