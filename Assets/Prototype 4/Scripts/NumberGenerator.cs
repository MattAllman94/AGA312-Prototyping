using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : JMC
{
    
    void Start()
    {
        AllocateNumber();
    }

    
    void Update()
    {

    }

    void AllocateNumber()
    {
        int rnd = Random.Range(0, 2);

        switch(rnd)
        {
            case 0:
                _UI4.number.text = "15";
                break;
            case 1:
                _UI4.number.text = "40";
                break;
            case 2:
                _UI4.number.text = "5";
                break;
        }
    }
}
