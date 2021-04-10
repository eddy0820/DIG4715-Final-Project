using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
 public GameObject towerPrefab;
 private GameObject tower;

    private bool Occupied()
    {
        return tower == null;
    }

    void OnMouseUp()
    {
        if (Occupied())
            {
                tower = (GameObject) 
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                EnemySpawner.instance.SetRoundStarted(true);
                //audio here if we want it
            }
    }
}
