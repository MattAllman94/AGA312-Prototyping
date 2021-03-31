using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RootScript : JMC
{

    public Transform worldAnchor;
    public Transform myAnchor;
    public Transform rootTip;

    private Camera mainCamera;
    private float camToDist;
    private Vector3 initialScale;
    public float maxDrag = 2;

    public bool isLocked = false;
    public Color lockedColor;



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
        if(isLocked == false)
        {
            Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camToDist);
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

            float dist = Vector3.Distance(worldAnchor.position, mouseWorldPos);
            transform.localScale = new Vector3(initialScale.x, dist / 2f, initialScale.z);

            Vector3 middlePoint = (worldAnchor.position + mouseWorldPos) / 2f;
            transform.position = middlePoint;

            Vector3 rotationDirection = (mouseWorldPos - worldAnchor.position);
            transform.up = rotationDirection;

            rootTip.position = mainCamera.ScreenToWorldPoint(mouseScreenPos);            
        }
    }

    public void LockRoot()
    {
        isLocked = true;
        worldAnchor = rootTip;
        _SM2.rootSpawnPos = worldAnchor;
        GetComponent<Renderer>().material.DOColor(lockedColor, 0);
    }
}
