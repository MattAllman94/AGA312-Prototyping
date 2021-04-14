using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : JMC
{
    public int currentNumber;
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
                currentNumber = 15;
                break;
            case 1:
                _UI4.number.text = "40";
                currentNumber = 40;
                break;
            case 2:
                _UI4.number.text = "5";
                currentNumber = 5;
                break;
        }
    }
}
