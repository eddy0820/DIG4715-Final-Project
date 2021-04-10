using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance { get; private set; }
    public GameObject Enemy;

    public int spawnCount;

    public float spawnDelay;
    
    public float spawnInterval;

    private int numSpawned;

    private bool roundStarted = false;

    private bool invokeCalled = false;

    public Text startText;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startText.text = "Place a tower down by left clicking to start the round!";
    }

    void Update()
    {
        if(roundStarted == true && invokeCalled == false)
        {
            InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
            invokeCalled = true;
            startText.text = "";
        }

        if(numSpawned == spawnCount)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(Enemy);
        numSpawned++;
    }

    public void SetRoundStarted(bool inRoundStarted)
    {
        roundStarted = inRoundStarted;
    }

    public bool GetIsPowered()
    {
        return roundStarted;
    }

}
