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
        public float rootCount = 1;
        private float maxRoots = 10;
        public Transform rootSpawnPos;


        public GameObject enemy;
        public float enemySpawnRate = 10; 


        void Start()
        {

        }


        void Update()
        {
            spawnRate -= Time.deltaTime;
            enemySpawnRate -= Time.deltaTime;
            SpawnNutrient();
            //SpawnEnemy();
        }

        void SpawnNutrient()
        {
            //int rnd = Random.Range(0, spawnPos.Length);
            if(spawnRate <= 0)
            {
                //Vector3 nutrientSpawnPos = SpawnPos();
                Vector3 nutrientSpawnPos = new Vector3(Random.Range(-9f,9f), Random.Range(-4f, 6f),0);
                //Debug.Log(nutrientSpawnPos);
                Instantiate(nutrient, new Vector3(nutrientSpawnPos.x, nutrientSpawnPos.y, 0), transform.rotation);
                spawnRate = 2;
            }
        }

        public void SpawnRoot(GameObject _parent)
        {
            
            if (rootCount < maxRoots)
            {
                int rnd = Random.Range(1, 3);

                switch(rnd)
                {
                    case 1:
                        GameObject root1 = makeRoot(_parent);
                        root1.name = "Root 1";
                        break;
                    case 2:
                        GameObject root21 = makeRoot(_parent);
                        root21.name = "Root 21";
                        GameObject root22 = makeRoot(_parent);
                        root22.name = "Root 22";
                        break;
                    case 3:
                        GameObject root31 = makeRoot(_parent);
                        root31.name = "Root 31";
                        GameObject root32 = makeRoot(_parent);
                        root32.name = "Root 32";
                        GameObject root33 = makeRoot(_parent);
                        root33.name = "Root 33";
                        break;
                }
                
            }
        }
        
        GameObject makeRoot(GameObject _parent)
        {
            Quaternion rootRotation = Quaternion.Euler(0, 0, Random.Range(-90, 90));
            //Debug.Log(rootRotation);

            //Vector3 offset = new Vector3(0, 1.5f, 0);

            GameObject newRoot = Instantiate(root, rootSpawnPos.position, rootRotation, root.transform.parent);
            newRoot.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            newRoot.GetComponentInChildren<RootScript>().worldAnchor = _parent.transform;
            
            rootCount += 1;
            newRoot.transform.SetParent(_parent.transform);
            return newRoot;
        }

        void SpawnEnemy()
        {
            //int rnd = Random.Range(0, spawnPos.Length);
            if (enemySpawnRate <= 0)
            {
                //Vector3 nutrientSpawnPos = SpawnPos();
                Vector3 enemySpawnPos = new Vector3(Random.Range(12f, 14f), Random.Range(3f, -3.5f), 0);
                Instantiate(enemy, new Vector3(enemySpawnPos.x, enemySpawnPos.y, 0), enemy.transform.rotation);
                Debug.Log(enemySpawnPos);
                enemySpawnRate = 10;
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
