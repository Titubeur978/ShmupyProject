using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMugger : Enemy
{
    void Start()
    {
        maxHealth = 1;
        speed = 12;
        RoF = 5;
        shootChance = 15;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
}
