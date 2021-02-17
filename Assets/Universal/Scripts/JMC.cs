using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMC : MonoBehaviour
{
    /// <summary>
   /// Use this to check if we should call Game Over
   /// </summary>
   /// <param name="_lives"> The players current lives </param>
   /// <returns> If we are at Game Over or not </returns>
    public bool IsGameOver(int _lives)
    {
        return _lives == 0;
    }

    /// <summary>
    /// Works out the change in percentage between two scores
    /// </summary>
    /// <param name="_score1"> The original score </param>
    /// <param name="_score2"> The new score </param>
    /// <returns> The percentage between two scores </returns>
    public float PercentageCheck (int _score1, int _score2)
    {
        float change = _score2 - _score1;
        return change / _score1 * 100;
    }
}
