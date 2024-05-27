using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossFinal : Enemy
{
    public Transform shootPoint2, shootPoint3, shootPoint4;
    public Transform shieldPoint1, shieldPoint2, shieldPoint3;
    public GameObject specialProjectile;
    public Transform specialShootPoint, specialShootPoint2;

    private bool isSpecialShooting = false;
    private float specialRoF;
    private int specialShootChance;

    void Start()
    {
        maxHealth = 50;
        speed = 4;
        RoF = 1;
        shootChance = 65;
        specialRoF = 2;
        specialShootChance = 15;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
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
                case 0: //front lasers
                    int frontShoot = Random.Range(0, 3);
                    switch (frontShoot)
                    {
                        case 0: //left then right
                            Instantiate(projectile, shootPoint3);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint4);
                            break;

                        case 1: //right then left
                            Instantiate(projectile, shootPoint4);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint3);
                            break;

                        case 2: //both
                            Instantiate(projectile, shootPoint3);
                            Instantiate(projectile, shootPoint4);
                            break;
                    }
                    break;
                case 1: //rear lasers
                    int rearShoot = Random.Range(0, 3);
                    switch (rearShoot)
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
                    break;
                case 2: //both front & rear lasers
                    int bothShoot = Random.Range(0, 7);
                    switch (bothShoot)
                    {
                        case 0: //rear left then right then front left then right
                            Instantiate(projectile, shootPoint);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint2);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(projectile, shootPoint3);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint4);
                            break;

                        case 1: //rear right then left then front right then left
                            Instantiate(projectile, shootPoint2);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(projectile, shootPoint4);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint3);
                            break;

                        case 2: //both rear then both front
                            Instantiate(projectile, shootPoint);
                            Instantiate(projectile, shootPoint2);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint3);
                            Instantiate(projectile, shootPoint4);
                            break;

                        case 3: //both front then both rear
                            Instantiate(projectile, shootPoint3);
                            Instantiate(projectile, shootPoint4);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint);
                            Instantiate(projectile, shootPoint2);
                            break;

                        case 4: //from furthest left to furthest right
                            Instantiate(projectile, shootPoint);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint3);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint4);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint2);
                            break;

                        case 5://from furthest right to furthest left
                            Instantiate(projectile, shootPoint2);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint4);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint3);
                            yield return new WaitForSeconds(0.1f);
                            Instantiate(projectile, shootPoint);
                            break;

                        case 6://all fire
                            Instantiate(projectile, shootPoint);
                            Instantiate(projectile, shootPoint2);
                            Instantiate(projectile, shootPoint3);
                            Instantiate(projectile, shootPoint4);
                            break;
                    }
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
        {
            int shootOrder = Random.Range(0, 5);
            switch (shootOrder)
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
