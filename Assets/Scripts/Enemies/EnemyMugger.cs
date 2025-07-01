using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMugger : Enemy
{
    protected override void Start()
    {
        health = 1;
        speed = 12;
        RoF = 5;
        shootChance = 15;
        base.Start();
    }
}
