using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : JMC
{
    public float rotateSpeed;


    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
        }


    }
}
