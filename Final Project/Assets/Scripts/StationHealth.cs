using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationHealth : MonoBehaviour
{
    public int maxHealth;
         
    public int health { get { return currentHealth; }}

    int currentHealth;

    SpriteRenderer sprite;

    private SceneManger manager;

    public Text stationHealthText;
    public Sprite[] spriteArray;
    public ParticleSystem particlePrefab;

    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        manager = GameObject.Find("Manager").GetComponent<SceneManger>();
        stationHealthText.text = "Health: " + currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        if (currentHealth == 6)
        {
            //audio for losing health would go here
           sprite.sprite = spriteArray[1];
           particlePrefab.Play();
        }

        if (currentHealth == 3)
        {
            //audio again
            sprite.sprite = spriteArray[2];
            particlePrefab.Play();
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
