using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype1
{
    public class GameManager : Singleton<GameManager>
    {

        public float currentTime;

        void Start()
        {
            currentTime = Time.deltaTime;
        }

        void Update()
        {
            if(_PC1.gameOver == false)
            {
                currentTime += Time.deltaTime;
            }
        }
    }
}