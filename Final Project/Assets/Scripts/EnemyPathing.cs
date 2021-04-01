using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public GameObject[] points;
    public GameObject EnemyPrefab;


    void Start()
    {
        Instantiate(EnemyPrefab).GetComponent<EnemyController>().points = points;
    }
}
