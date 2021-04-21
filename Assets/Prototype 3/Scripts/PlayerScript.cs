using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float slideSpeed;
    public bool godMode;

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.localPosition.y <= 5)
            {
                transform.localPosition += (Vector3.up * slideSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 newPos = new Vector3(0, 5, 0);
                transform.localPosition = newPos;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.localPosition.y >= 0.5f)
            {
                transform.localPosition += (-Vector3.up * slideSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 newPos = new Vector3(0, 0.5f, 0);
                transform.localPosition = newPos;
            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            godMode = true;
        }
        else
        {
            godMode = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!godMode)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }
        }

    }
}
