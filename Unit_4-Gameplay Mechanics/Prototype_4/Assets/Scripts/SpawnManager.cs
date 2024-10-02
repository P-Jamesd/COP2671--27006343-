using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefabs;
    public int enemyCount;
    public int waveNumber = 1; 
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab,GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab,GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosz = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,0, spawnPosz);
        return randomPos;
    }
    void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i=0; i<enemyToSpawn; i++)
        {
        Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation);
        }
    }
}
