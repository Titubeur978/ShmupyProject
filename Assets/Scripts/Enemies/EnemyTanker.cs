using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTanker : Enemy
{
    public Transform ShieldPoint;

    void Start()
    {
        maxHealth = 15;
        speed = 5;
        RoF = 3;
        shootChance = 20;
    }
}
