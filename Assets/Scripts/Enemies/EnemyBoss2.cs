using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss2 : Enemy
{
    public Transform shootPoint2, shieldPoint;
    public GameObject specialProjectile;
    public Transform specialShootPoint;
    public GameObject shield2nd;

    private bool isSpecialShooting = false;
    private float specialRoF;
    private int specialShootChance;

    protected override void Start()
    {
        health = 35;
        speed = 4;
        RoF = 3;
        shootChance = 40;
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

    public override void Shoot()
    {
        StartCoroutine(Shooting(RoF));
    }

    public void SpecialShoot()
    {
        StartCoroutine(SpecialShooting(specialRoF));
    }

    IEnumerator Shooting(float RoF)
    {
        isShooting = true;
        int shootRNG = Random.Range(0, 100);
        if (shootRNG > (100 - shootChance))
        {
            int shootOrder = Random.Range(0, 3);
            switch (shootOrder)
            {
                case 0: //left then right
                    Instantiate(projectile, shootPoint);
                    yield return new WaitForSeconds(0.1f);
                    Instantiate(projectile, shootPoint2);
                    break;

                case 1: //right then left
                    Instantiate(projectile, shootPoint2);
                    yield return new WaitForSeconds(0.1f);
                    Instantiate(projectile, shootPoint);
                    break;

                case 2: //both
                    Instantiate(projectile, shootPoint);
                    Instantiate(projectile, shootPoint2);
                    break;
            }
        }
        yield return new WaitForSeconds(1 / RoF);
        isShooting = false;
    }

    IEnumerator SpecialShooting(float specialRoF)
    {
        isSpecialShooting = true;
        int rng = Random.Range(0, 100);
        if (rng > (100 - specialShootChance))
            Instantiate(specialProjectile, specialShootPoint);
        yield return new WaitForSeconds(1 / specialRoF);
        isSpecialShooting = false;
    }
}
