using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PickupType
{
    SPEED,
    SLOW
}

public class Pickups : JMC
{
    public Camera cam;
    public PickupType myType;
    public Ease ease;

    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 punch = new Vector3(1.5f, 1.5f, 1.5f);
            _OM.SpeedUp();
            gameObject.transform.DOPunchScale(punch, 0.1f, 5, 0);
            cam.DOFieldOfView(170, 3).SetEase(ease);
            Destroy(this.gameObject, 0.2f);
        }
    }

}
