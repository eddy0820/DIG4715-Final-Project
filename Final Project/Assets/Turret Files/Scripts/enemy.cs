using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigidbody2D;

    int direction = 1;

    private void Awake()
    {
        Enemies.enemies.Add(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

   

    void Update()
    {

    }

    void FixedUpdate()
    {

        Vector2 position = rigidbody2D.position;

        position.x = position.x + Time.deltaTime * speed * direction;
        rigidbody2D.MovePosition(position);

    }

    void Die()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            Die();
            Destroy(this.gameObject);
        }

    }

}
