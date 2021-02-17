using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : JMC
{

    public int lastRoundScore = 100;
    public int thisRoundScore = 150;
    public int lives = 5;

    void Start()
    {
        if(IsGameOver(lives))
        {
            CheckScore();
        }

    }

    void CheckScore()
    {
        print("Score difference is : " + PercentageCheck(lastRoundScore, thisRoundScore).ToString("F1") + "%");
    }

}
