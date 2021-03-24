using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutrientManager : MonoBehaviour
{
    public float decay = 5;

    void Start()
    {
        
    }

    void Update()
    {
        decay -= Time.deltaTime;

        if(decay <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
