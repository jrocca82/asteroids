using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidSpawns;

    float maxTime = 3;

    float minTime = 1;

    private float time;

    private float spawnTime;

    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        while (time > spawnTime)
        {
            GenerateAsters();
        }
    }

    void GenerateAsters()
    {
        time = 0;
        int i = Random.Range(0, asteroidSpawns.Length);
        GameObject asterclone = Instantiate(asteroidSpawns[i]);
        asterclone.transform.position = Random.insideUnitCircle * 5;
    }

    void SetRandomTime(){
        spawnTime = Random.Range(minTime, maxTime);
    }
}
