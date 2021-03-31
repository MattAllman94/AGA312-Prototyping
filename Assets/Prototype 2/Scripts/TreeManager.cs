using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : Singleton<TreeManager>
{
    public float waterLevel = 50;
    public bool isDrinking = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isDrinking == false)
        {
            waterLevel -= Time.deltaTime;
        }
    }
}
