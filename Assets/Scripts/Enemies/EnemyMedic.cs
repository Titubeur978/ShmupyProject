using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedic : Enemy
{
    public GameObject specialProjectile;
    public Transform specialShootPoint;
    public EnemyTanker Tanker;
    private Rigidbody2D TankerRb;

    private float specialRoF;
    private int specialShootChance;
    private bool isSpecialShooting = false;

    void Start()
    {
        maxHealth = 10;
        speed = 5;
        RoF = 5;
        shootChance = 0;
        specialRoF = 1;
        specialShootChance = 30;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);

        if (!isMoving)
            Move();
        //make him shoot healing pulse from his ass
        if (Tanker != null)
        {
            //make it move according to tanker's moves
        }
        else
        {
            //make him shoot death lazers of revenge
            speed = 7;
            RoF = 2;

            shootChance = 20;
            specialRoF = 5;
            specialShootChance = 10;
            if (!isShooting)
                Shoot();

            if (!isSpecialShooting)
                SpecialShoot();
        }
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
            Instantiate(specialProjectile, specialShootPoint);
        yield return new WaitForSeconds(1 / specialRoF);
        isSpecialShooting = false;
    }

    public void SetVel(Vector2 vel)
    { mov = vel; }

    public override void Move()
    {
        if (Tanker != null)
            StartCoroutine(MovingWithTanker());
        else
            StartCoroutine(Moving());
    }

    IEnumerator MovingWithTanker()
    {
        rb.velocity = mov * speed;
        yield return new WaitForSeconds(2 / speed);
    }

    
}