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

    private void Awake () 
    {
        Enemies.enemies.Add (gameObject);
        currentHealth = maxHealth;
        enemyHealth.SetMaxHealth(maxHealth);
    }

    void Start () {
        lastPoint = Time.time;
    }

    void Update () {
        Vector3 startPosition = points[currentPath].transform.position;
        Vector3 endPosition = points[currentPath + 1].transform.position;

        float pathLength = Vector3.Distance (startPosition, endPosition);
        float totalTime = pathLength / speed;
        float currentTime = Time.time - lastPoint;

        gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, currentTime / totalTime);

        if (gameObject.transform.position.Equals (endPosition)) {
            if (currentPath < points.Length - 2) {
                currentPath++;
                lastPoint = Time.time;
            } else {
                Destroy (gameObject);
            }
        }
    }

    void Die () 
    {
        Enemies.enemies.Remove (gameObject);
        Destroy (transform.gameObject);

    }

    void OnCollisionEnter2D (Collision2D other) 
    {
        StationHealth enemy = other.gameObject.GetComponent<StationHealth> ();

        if (enemy != null) 
        {
            enemy.ChangeHealth (-1);
            Debug.Log ("You lost health!");
        }

        if (other.gameObject.CompareTag ("Bullet")) 
        {
            Damage(20);

                if (currentHealth == 0)
                {
                   Die ();
                   Destroy (this.gameObject); 
                }
            
        }
    }

    private void stopSpawning () 
    {
        enemiesSpawned--;
    }

    void Damage (int damage)
    {
        currentHealth -= damage;
        enemyHealth.SetHealth(currentHealth);
    }
}