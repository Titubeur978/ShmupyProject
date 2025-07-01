using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss3 : Enemy
{
    public Transform shieldPoint;
    public GameObject specialProjectile;
    public Transform specialShootPoint, specialShootPoint2;

    private bool isSpecialShooting = false;
    private float specialRoF;
    private int specialShootChance;

    protected override void Start()
    {
        health = 40;
        speed = 4;
        RoF = 3;
        shootChance = 50;
        specialRoF = 1;
        specialShootChance = 10;
        base.Start();
    }

    void FixedUpdate()
    {
        if (!isSpecialShooting)
            SpecialShoot();

        if (currentHealth <= 0)
            Destroy(gameObject);

        if (!isShooting)
            Shoot();

        if (!isMoving)
            Move();
    }

    public void SpecialShoot()
    {
        StartCoroutine(SpecialShooting(specialRoF));
    }

    IEnumerator SpecialShooting(float specialRoF)
    {
        isSpecialShooting = true;
        int rng = Random.Range(0, 100);
        if (rng > (100 - specialShootChance))
        {
            int shootOrder = Random.Range(0, 5);
            switch(shootOrder) 
            {
                case 0://left
                    Instantiate(specialProjectile, specialShootPoint);
                    break;
                case 1://left too
                    Instantiate(specialProjectile, specialShootPoint);
                    break;
                case 2://right
                    Instantiate(specialProjectile, specialShootPoint2);
                    break;
                case 3://right too
                    Instantiate(specialProjectile, specialShootPoint2);
                    break;
                case 4://both
                    Instantiate(specialProjectile, specialShootPoint);
                    Instantiate(specialProjectile, specialShootPoint2);
                    break;
            }
        }
        yield return new WaitForSeconds(1 / specialRoF);
        isSpecialShooting = false;
    }

}
