using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Prototype3
{
    public class SpawnManager : Singleton<SpawnManager>
    {
        public Camera cam;

        public GameObject obstacle;
        private int obstacleLimit = 50;
        public int currentNumber = 0;
        public float spawnRate;
        public float currentSpawnRate;
        public List<ObstacleMovement> obstacles;

        public GameObject[] pickup;
        public float pickupSpawnRate;
        public float currentPickupSpawnRate;

        public float currentSpeed;
        public float speed;
        public float defaultSpeed;
        public Ease ease;

        float cooldown = 0;

        void Start()
        {
            cam = Camera.main;
        }

        void Update()
        {
            currentSpawnRate -= Time.deltaTime;
            SpawnObstacle();

            currentPickupSpawnRate -= Time.deltaTime;
            SpawnPickup();

            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                SpeedDown(defaultSpeed);
            }
        }

        void SpawnPickup()
        {
            if(currentPickupSpawnRate <= 0)
            {
                int rnd = Random.Range(0, pickup.Length);
                //Vector3 pickupSpawnPos = new Vector3(Random.Range(-12f, 12f), Random.Range(14f, -12f), 0);
                Vector3 pickupSpawnPos = new Vector3(Random.Range(-5f, 5f), Random.Range(4f, -4f), 0);
                Instantiate(pickup[rnd], new Vector3(pickupSpawnPos.x, pickupSpawnPos.y, 30), transform.rotation);
                currentPickupSpawnRate = pickupSpawnRate;
            }
        }

        void SpawnObstacle()
        {
            if (obstacles.Count <= obstacleLimit)
            {
                if (currentSpawnRate <= 0)
                {
                    Vector3 obstacleSpawnPos = new Vector3(Random.Range(-13f, 13f), Random.Range(14f, -12f), 0);
                    //Vector3 obstacleSpawnPos = new Vector3(Random.Range(-5f, 5f), Random.Range(4f, -4f), 0);
                    GameObject go = Instantiate(obstacle, new Vector3(obstacleSpawnPos.x, obstacleSpawnPos.y, 30), transform.rotation);
                    currentSpawnRate = spawnRate;
                    obstacles.Add(go.GetComponent<ObstacleMovement>());
                }
            }
        }

        public void SpeedUp(float _speed)
        {
            cooldown = 10;
            DOTween.To(() => speed, x => speed = x, _speed, 3).SetEase(ease).OnUpdate(() => currentSpeed = speed);
            cam.DOFieldOfView(170, 3).SetEase(ease);
        }

        public void SpeedDown(float _speed)
        {
            DOTween.To(() => speed, x => speed = x, _speed, 3).SetEase(ease).OnUpdate(() => currentSpeed = speed);
            cam.DOFieldOfView(60, 3).SetEase(ease);
        }
    }
}
