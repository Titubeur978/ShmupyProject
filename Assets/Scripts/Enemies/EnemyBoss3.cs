using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss3 : Enemy
{
    public Transform ShieldPoint;
    public GameObject SpecialProjectile;
    public Transform SpecialShootPoint, SpecialShootPoint2;

    private float specialRoF;
    private int specialShootChance;

    void Start()
    {
        maxHealth = 40;
        speed = 4;
        RoF = 3;
        shootChance = 65;
        specialRoF = 1;
        specialShootChance = 10;
    }
}
