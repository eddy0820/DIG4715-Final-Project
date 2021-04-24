using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance { get; private set; }

    public GameObject Enemy;

    public int spawnCount = 5;

    public float spawnDelay;
    
    public float spawnInterval;

    private int numSpawned;

    private bool roundStarted = false;

    private bool invokeCalled = false;

    public Text startText;

    private int enemiesDestroyed = 0;

    private SceneManger manager;

    private StationHealth station;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startText.text = "Place a tower down by left clicking to start the round!";
        manager = GameObject.Find("Manager").GetComponent<SceneManger>();
        station = GameObject.Find("Station").GetComponent<StationHealth>();
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

        if(enemiesDestroyed == spawnCount && station.health > 0)
        {
            manager.gameWin = true;
            manager.SwitchScene();
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

    public void IncrementEnemiesDestroyed()
    {
        enemiesDestroyed++;
    }

}
