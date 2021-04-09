﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTrack : MonoBehaviour {
    public Transform enemy;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start () 
    {
        rb = this.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () 
    {
        Vector3 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize ();
        movement = direction;
    }
}