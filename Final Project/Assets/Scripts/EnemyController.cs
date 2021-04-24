using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject[] points;

    private int currentPath = 0;

    private float lastPoint;

    public float speed = 1.0f;

    private int enemiesSpawned = 0;

    public int maxHealth = 100;

    public int currentHealth;

    public EnemyHealth enemyHealth;

    public int economyGiven = 1;

    public int damageToStation = -1;

    private bool stopBulletCollisions = false;
    public ParticleSystem brokenPrefab;

    private void Awake() 
    {
        Enemies.enemies.Add (gameObject);
        currentHealth = maxHealth;
        enemyHealth.SetMaxHealth(maxHealth);
    }

    void Start() 
    {
        lastPoint = Time.time;
    }

    void Update () 
    {
        Vector3 startPosition = points[currentPath].transform.position;
        Vector3 endPosition = points[currentPath + 1].transform.position;

        float pathLength = Vector3.Distance (startPosition, endPosition);
        float totalTime = pathLength / speed;
        float currentTime = Time.time - lastPoint;

        gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, currentTime / totalTime);

        if (gameObject.transform.position.Equals (endPosition)) 
        {
            if (currentPath < points.Length - 2) 
            {
                currentPath++;
                lastPoint = Time.time;
            } 
            else 
            {
                Die();
            }
        }
    }

    void Die() 
    {
        Enemies.enemies.Remove (gameObject);
        Destroy(this.gameObject); 
        Economy.instance.UpdateEconomy(economyGiven);
        EnemySpawner.instance.IncrementEnemiesDestroyed();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        StationHealth station = other.gameObject.GetComponent<StationHealth> ();

        if (station != null) 
        {
            station.ChangeHealth(damageToStation);
            Debug.Log ("You lost " + damageToStation + " health!");
        }

        if (stopBulletCollisions == false && other.gameObject.CompareTag ("Bullet")) 
        {
            Damage(20);

            if (currentHealth <= 0)
            {
                Die();
                stopBulletCollisions = true;
                brokenPrefab.Play();
            }
            
        }
    }

    private void stopSpawning() 
    {
        enemiesSpawned--;
    }

    void Damage (int damage)
    {
        currentHealth -= damage;
        enemyHealth.SetHealth(currentHealth);
    }
}