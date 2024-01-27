using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : Enemy
{
    public Transform ShootPoint2;

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
        int rng = Random.Range(0, 100);
        if (rng > (100 - shootChance))
        {
            Instantiate(projectile, shootPoint);

            yield return new WaitForSeconds(0.1f);
            Instantiate(projectile, ShootPoint2);
        }
        yield return new WaitForSeconds(1 / RoF);
        isShooting = false;
    }
}
