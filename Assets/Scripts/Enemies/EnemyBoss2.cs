using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss2 : Enemy
{
    public Transform shootPoint2, shieldPoint;
    public GameObject specialProjectile;
    public Transform specialShootPoint;
    public GameObject Shield2nd;

    private float specialRoF;
    private int specialShootChance;
    
    void Start()
    {
        maxHealth = 35;
        speed = 4;
        RoF = 3;
        shootChance = 40;
        specialRoF = 1;
        specialShootChance = 10;
    }

    public override void Shoot()
    {
        StartCoroutine(Shooting(RoF));
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
}
