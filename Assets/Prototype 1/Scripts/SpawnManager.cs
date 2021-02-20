using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacle;

    //private Vector3 spawnPos = new Vector3(25, 0, 0);
    public Transform spawnPos;
    private float startDelay = 2;
    public float[] repeatRate;
    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate[Random.Range(0, repeatRate.Length)]); // Trying to get the obstacles randomly spawning at different times
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], spawnPos.position, spawnPos.rotation);
            print(repeatRate[repeatRate.Length - 1]);
        }
    }
}
