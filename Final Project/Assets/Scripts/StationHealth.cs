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
    public AudioClip damageSound;
    AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        manager = GameObject.Find("Manager").GetComponent<SceneManger>();
        stationHealthText.text = "Health: " + currentHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeHealth(int amount)
    {
        if (currentHealth == 6)
        {
            audioSource.PlayOneShot(damageSound);
           sprite.sprite = spriteArray[1];
           particlePrefab.Play();
        }

        if (currentHealth == 3)
        {
            audioSource.PlayOneShot(damageSound);
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
