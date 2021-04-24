using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public static Economy instance { get; private set; }

    public int startingEconomy = 10;

    public Text economyText;

    private int currentEconomy;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentEconomy = startingEconomy;
        economyText.text = "Screws: " + startingEconomy;
    }

    void Update()
    {
        economyText.text = "Screws: " + currentEconomy;
    }

    public void UpdateEconomy(int inEconomy)
    {
        currentEconomy = currentEconomy + inEconomy;
    }

    public void PlaceTower(int inCost)
    {  
        currentEconomy = currentEconomy - inCost;      
    }
    
    public int GetCurrentEconomy()
    {
        return currentEconomy;
    }
}
