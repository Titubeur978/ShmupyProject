using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : Enemy
{
    public Transform ShootPoint2;

    void Start()
    {
        maxHealth = 30;
        speed = 4;
        RoF = 3;
    }
}
