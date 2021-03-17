using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype2
{
    public class SpawnManager : Singleton<SpawnManager>
    {

        public GameObject nutrient;
        //public Transform[] spawnPos;
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
            //int rnd = Random.Range(0, spawnPos.Length);
            if(spawnRate <= 0)
            {
                //Vector3 nutrientSpawnPos = SpawnPos();
                Vector3 nutrientSpawnPos = new Vector3(Random.Range(-10f,10f), Random.Range(-10f, 10f),0);
                Debug.Log(nutrientSpawnPos);
                Instantiate(nutrient, new Vector3(nutrientSpawnPos.x, nutrientSpawnPos.y, 0), transform.rotation);
                spawnRate = 2;
            }
        }

        public void SpawnRoot(GameObject _parent)
        {
            
            if (rootCount < maxRoots)
            {
                GameObject newRoot = Instantiate(root, rootSpawnPos.position, transform.rotation);
                newRoot.GetComponentInChildren<DragScript>().worldAnchor = _parent.transform;
                rootCount += 1;
            }
        }

        Vector3 SpawnPos()
        {
            float randX = Random.Range(-10, 10);
            float randY = Random.Range(-10, 10);



            Vector3 spawnPos = new Vector3(randX, randY, -100f);
            RaycastHit hit;
            if (Physics.Raycast(spawnPos, Vector3.forward, out hit, 100f))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Root"))
                {
                    return SpawnPos(); // Repeats the function
                }
                else
                {
                    return spawnPos;
                }
            }
            else
            {
                return SpawnPos(); // Repeats the function if the ray misses the ground
            }
        }

    }

}
