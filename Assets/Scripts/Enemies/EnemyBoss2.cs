using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss2 : Enemy
{
    public Transform ShootPoint2, ShieldPoint;
    public GameObject SpecialProjectile;
    public Transform SpecialShootPoint;

    private float specialRoF;
    private int specialShootChance;
    
    void Start()
    {
        maxHealth = 35;
        speed = 4;
        RoF = 3;
        specialRoF = 1;
        specialShootChance = 10;
    }
}
