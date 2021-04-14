using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCheck : MonoBehaviour
{
    public enum Operator
    {
        ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION
    }

    public List<int> vialNumbers;
    public int myNumber;
    public Operator myOperator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<NumberHolder>())
        {
            vialNumbers.Add(other.GetComponent<NumberHolder>().myNumber);
            Destroy(other.gameObject);
        }
    }

    public void CheckAnswer()
    {
        if(vialNumbers.Count < 2)
        {
            return;
        }

        int temp = vialNumbers[0];

        switch (myOperator)
        {
            case Operator.ADDITION:
                for (int i = 1; i < vialNumbers.Count; i++)
                {
                    temp += i;
                }
                break;
            case Operator.SUBTRACTION:
                for(int i = 1; i < vialNumbers.Count; i++)
                {
                    temp -= i;
                }
                break;
            case Operator.MULTIPLICATION:
                for (int i = 1; i < vialNumbers.Count; i++)
                {
                    temp *= i;
                }
                break;
            case Operator.DIVISION:
                for (int i = 1; i < vialNumbers.Count; i++)
                {
                    temp /= i;
                }
                break;
        }

        if(temp == myNumber)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Lose");
        }
    }
}
