using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBandit : Enemy
{
    protected override void Start()
    {
        health = 2;
        speed = 10;
        RoF = 5;
        shootChance = 15;
        base.Start();
    }
}
