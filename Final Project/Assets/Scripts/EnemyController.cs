using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
     public GameObject[] points;
     private int currentPath = 0;
     private float lastPoint;
     public float speed = 1.0f;

    void Start()
    {
         lastPoint = Time.time;
    }

    void Update()
    {   
         Vector3 startPosition = points [currentPath].transform.position;
         Vector3 endPosition = points [currentPath + 1].transform.position;

         float pathLength = Vector3.Distance (startPosition, endPosition);
         float totalTime = pathLength / speed;
         float currentTime = Time.time - lastPoint;

         gameObject.transform.position = Vector2.Lerp (startPosition, endPosition, currentTime / totalTime);

            if (gameObject.transform.position.Equals(endPosition)) 
                {
                    if (currentPath < points.Length - 2)
                        {
                            currentPath++;
                            lastPoint = Time.time;
                        }

                    else
                        {
                            Destroy(gameObject);
                        }
                }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StationHealth enemy = other.gameObject.GetComponent<StationHealth>();

        if (enemy != null)
        {
            enemy.ChangeHealth(-1);
            Debug.Log("You lost health!");
        }
    }


}
