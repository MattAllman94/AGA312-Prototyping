using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NumberGenerator : JMC
{
    public enum Difficulty
    {
        EASY, MEDIUM, HARD
    }

    public int answer;
    public List<GameObject> numberHolders;
    public Difficulty currentDifficulty;
    public int vialCount;
    public GameObject vialPrefab;
    public NumberCheck additionCauldron;
    public NumberCheck subtractionCauldron;
    public NumberCheck multiplicationCauldron;
    public NumberCheck divisionCauldron;

    void Start()
    {
        AllocateNumber();
    }

    
    void Update()
    {

    }

    void AllocateNumber()
    {
        numberHolders.Clear();
        additionCauldron.vialNumbers.Clear();
        subtractionCauldron.vialNumbers.Clear();
        multiplicationCauldron.vialNumbers.Clear();
        divisionCauldron.vialNumbers.Clear();

        for (int i = 0; i < vialCount; i++)
        {
            GameObject go = Instantiate(vialPrefab, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), transform.rotation);
            go.GetComponent<NumberHolder>().myNumber = GetRandomNumbers();
            go.name = "Vial " + go.GetComponent<NumberHolder>().myNumber.ToString();
            go.GetComponentInChildren<TextMeshPro>().text = go.GetComponent<NumberHolder>().myNumber.ToString();
            numberHolders.Add(go);
        }

        int rnd = Random.Range(0, 3);
        
        switch(rnd)
        {
            case 0:
                GetAddition();
                break;
            case 1:
                GetSubtraction();
                break;
            case 2:
                GetMultiplication();
                break;
            case 3:
                GetDivision();
                break;
        }

    }

    void GetAddition()
    {
        answer = numberHolders[0].GetComponent<NumberHolder>().myNumber + numberHolders[1].GetComponent<NumberHolder>().myNumber;
        additionCauldron.myNumber = answer;
        _UI4.number.text = answer.ToString();
    }

    void GetSubtraction()
    {
        answer = numberHolders[0].GetComponent<NumberHolder>().myNumber - numberHolders[1].GetComponent<NumberHolder>().myNumber;
        subtractionCauldron.myNumber = answer;
        _UI4.number.text = answer.ToString();
    }

    void GetMultiplication()
    {
        answer = numberHolders[0].GetComponent<NumberHolder>().myNumber * numberHolders[1].GetComponent<NumberHolder>().myNumber;
        multiplicationCauldron.myNumber = answer;
        _UI4.number.text = answer.ToString();
    }

    void GetDivision()
    {
        answer = numberHolders[0].GetComponent<NumberHolder>().myNumber / numberHolders[1].GetComponent<NumberHolder>().myNumber;
        divisionCauldron.myNumber = answer;
        _UI4.number.text = answer.ToString();
    }

    int GetRandomNumbers()
    {
        switch (currentDifficulty)
        {
            case Difficulty.EASY:
                return (Random.Range(1, 10));
            case Difficulty.MEDIUM:
                return (Random.Range(1, 20));
            case Difficulty.HARD:
                return (Random.Range(1, 100));
            default:
                return (Random.Range(1, 10));
        }
    }


}
