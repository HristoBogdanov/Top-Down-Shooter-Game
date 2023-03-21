using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }
    public Wave[] waves;
    public Transform[] spanwPoints;
    public float timeBetweenWaves;

    private Wave currrentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool finishedSpawning;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }
    IEnumerator StartNextWave(int index)
    { 
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currrentWave = waves[index];
        for (int i = 0; i < currrentWave.count; i++)
        {
            if (player==null)
            {
                yield break;
            }
            else
            {
                Enemy randomEnemy = currrentWave.enemies[Random.Range(0, currrentWave.enemies.Length)];
                Transform randomSpot = spanwPoints[Random.Range(0, spanwPoints.Length)];
                Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

                if (i==currrentWave.count-1)
                {
                    finishedSpawning = true;
                }
                else
                {
                    finishedSpawning = false;
                }

                yield return new WaitForSeconds(currrentWave.timeBetweenSpawns);
            }
        }
    }
    private void Update()
    {
        if (finishedSpawning==true && GameObject.FindGameObjectsWithTag("Enemy").Length==0)
        {
            finishedSpawning = false;
            if (currentWaveIndex+1<waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                Debug.Log("Game Finished");
            }
        }
    }
}
