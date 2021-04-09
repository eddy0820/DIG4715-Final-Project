using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public int spawnCount;

    public float spawnDelay;
    
    public float spawnInterval;

    private int numSpawned;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
    }

    void Update()
    {
        if(numSpawned == spawnCount)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy()
    {
        numSpawned++;
        Instantiate(Enemy);
    }

}
