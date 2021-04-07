using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationHealth : MonoBehaviour
{
     public int maxHealth = 3;
         
     public int health { get { return currentHealth; }}
     int currentHealth;
     SpriteRenderer sprite;

    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            //audio for losing health would go here
            sprite.color = new Color (1, 0, 0, 1);
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
