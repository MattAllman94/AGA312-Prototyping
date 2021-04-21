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

    public PickupType myType;
    public Ease ease;

    void Start()
    {

    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 punch = new Vector3(1.5f, 1.5f, 1.5f);
            _SM3.SpeedUp(_SM3.currentSpeed + 15);
            gameObject.transform.DOPunchScale(punch, 0.1f, 5, 0);
            Destroy(this.gameObject, 0.2f);
        }
    }

}
