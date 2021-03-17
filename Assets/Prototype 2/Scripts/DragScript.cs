using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : JMC
{


    public Transform worldAnchor;
    
    private Camera mainCamera;
    private float camToDist;
    private Vector3 initialScale;



    void Start()
    {
        initialScale = transform.localScale;
        mainCamera = Camera.main;
        camToDist = mainCamera.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {

    }

    void OnMouseDrag()
    {
        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camToDist);
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        float dist = Vector3.Distance(worldAnchor.position, mouseWorldPos);
        transform.localScale = new Vector3(initialScale.x, dist / 2f, initialScale.z);
        
        Vector3 middlePoint = (worldAnchor.position + mouseWorldPos) / 2f;
        transform.position = middlePoint;

        Vector3 rotationDirection = (mouseWorldPos - worldAnchor.position);
        transform.up = rotationDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Nutrient"))
        {
            _GM2.nutrientCount += 1;
            Destroy(other.gameObject);
        }
    }
}
