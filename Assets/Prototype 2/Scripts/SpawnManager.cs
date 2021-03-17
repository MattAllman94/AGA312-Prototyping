using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype2
{
    public class SpawnManager : Singleton<SpawnManager>
    {

        public GameObject nutrient;
        public Transform[] spawnPos;
        public float spawnRate = 2;

        public GameObject root;
        public float rootCount;
        private float maxRoots = 10;
        public Transform rootSpawnPos;

        void Start()
        {

        }


        void Update()
        {
            spawnRate -= Time.deltaTime;
            SpawnNutrient();
        }

        void SpawnNutrient()
        {
            int rnd = Random.Range(0, spawnPos.Length);
            if(spawnRate <= 0)
            {
                Instantiate(nutrient, spawnPos[rnd].position, spawnPos[rnd].rotation);
                spawnRate = 2;
            }
        }

        public void SpawnRoot()
        {
            if (rootCount < maxRoots)
            {
                Instantiate(root, rootSpawnPos.position, rootSpawnPos.rotation);
                rootCount += 1;
            }
        }

    }

}
