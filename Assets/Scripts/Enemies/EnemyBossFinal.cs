using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossFinal : Enemy
{
    public Transform ShootPoint2, ShootPoint3, ShootPoint4;
    public Transform ShieldPoint1, ShieldPoint2, ShieldPoint3;
    public GameObject SpecialProjectile;
    public Transform SpecialShootPoint1, SpecialShootPoint2;

    private float specialRoF;
    private int specialShootChance;

    void Start()
    {
        maxHealth = 50;
        speed = 4;
        RoF = 4;
        specialRoF = 2;
        specialShootChance = 15;
    }
}
