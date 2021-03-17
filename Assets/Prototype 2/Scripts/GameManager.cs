using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype2
{

    public class GameManager : Singleton<GameManager>
    {

        public int nutrientCount;

        void Start()
        {

        }

        void Update()
        {
            if (nutrientCount == 3)
            {
                _SM2.SpawnRoot();
                nutrientCount = 0;
            }
        }
    }
}
