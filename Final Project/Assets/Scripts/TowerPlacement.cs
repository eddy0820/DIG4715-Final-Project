using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab;

    private GameObject tower;

    public int towerCost = 5;

    private bool Occupied()
    {
        return tower == null;
    }

    void OnMouseUp()
    {
        if(Occupied())
        {
            if(Economy.instance.GetCurrentEconomy() >= towerCost)
            {
                tower = (GameObject) 
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                EnemySpawner.instance.SetRoundStarted(true);
                Economy.instance.PlaceTower(towerCost);
                //audio here if we want it
            }
        }
    }
}
