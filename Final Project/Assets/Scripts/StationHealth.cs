using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationHealth : MonoBehaviour
{
    public int maxHealth = 3;
         
    public int health { get { return currentHealth; }}

    int currentHealth;

    SpriteRenderer sprite;

    private SceneManger manager;

    public Text stationHealthText;

    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        manager = GameObject.Find("Manager").GetComponent<SceneManger>();
        stationHealthText.text = "Health: " + currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            //audio for losing health would go here
            sprite.color = new Color (1, 0, 0, 1);
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        stationHealthText.text = "Health: " + currentHealth;

        if (currentHealth <= 0)
        {
            manager.gameOver = true;
            manager.SwitchScene();
        }
    }
}
