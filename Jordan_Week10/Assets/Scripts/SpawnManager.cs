using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    

    public float spawnRange = 20f;

    [Header("Prefabs")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bossPrefab;

    [Header("Enemies")]
    public int totalEnemies;
    public int wave = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(totalEnemies);
 
    }

    // Update is called once per frame
    void Update()
    {
        totalEnemies = FindObjectsOfType<navMeshScript>().Length;
        if (totalEnemies == 0)
        {
            wave++;

            if (wave % 5 == 0 && wave != 0)
            {
                int extraBossCount = wave / 5;
                for (int i = 0; i < extraBossCount; i++)
                {
                    SpawnBoss();
                }
            }
            else
            {
                SpawnEnemy(wave);
            }
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    void SpawnBoss()
    {
        Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
    }
}
