using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedic : Enemy
{
    public GameObject SpecialProjectile;
    public Transform SpecialShootPoint;
    public GameObject Tanker;

    private float specialRoF;
    private int specialShootChance;

    void Start()
    {
        maxHealth = 10;
        speed = 5;
        RoF = 5;
        shootChance = 0;
        specialRoF = 1;
        specialShootChance = 30;
    }

    void Update()
    {
        //make him shoot healing pulse from his ass
        if(Tanker == null)
        {
            //make him shoot death lazers of revenge
            speed = 7;
            RoF = 2;

            shootChance = 20;
            specialRoF = 5;
            specialShootChance = 10;
        }
    }
}
