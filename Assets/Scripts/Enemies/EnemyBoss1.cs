using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : Enemy
{
    public Transform shootPoint2;

    void Start()
    {
        maxHealth = 30;
        speed = 4;
        RoF = 3;
        shootChance = 40;
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
            int shootOrder = Random.Range(0, 2);
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
            }
        }
        yield return new WaitForSeconds(1 / RoF);
        isShooting = false;
    }
}
