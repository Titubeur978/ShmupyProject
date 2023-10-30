using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBandit : Enemy
{
    void Start()
    {
        maxHealth = 2;
        speed = 10;
        RoF = 5;
        shootChance = 15;
    }
}
