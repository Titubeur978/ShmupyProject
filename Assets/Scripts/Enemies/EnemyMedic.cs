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
    private float healRadius;
    private int healAmmount;
    private float healDuration;
    private bool isSpecialShooting = false;


    void Start()
    {
        maxHealth = 10;
        speed = 5;
        RoF = 5;
        shootChance = 0;
        specialRoF = 1f;
        specialShootChance = 30;
        healRadius = 5f;
        healAmmount = 2;
        healDuration = 5f;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);

        if (!isMoving)
            Move();

        if (Tanker != null)
        {
            if (!isSpecialShooting)
                SpecialShoot();
        }
        else
        {
            //make him shoot death lazers of revenge
            speed = 7;
            RoF = 2;

            shootChance = 20;
            specialRoF = 5f;
            specialShootChance = 10;
            healDuration = 1.5f;
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
        {
            if (Tanker != null && Tanker.getHealth() != Tanker.getMaxHealth())
            {
                StartCoroutine(HealTanker());
            }
            else
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, healRadius);
                foreach (var hit in hits)
                {
                    if (hit.gameObject != this.gameObject && hit.gameObject != Tanker.gameObject && hit.CompareTag("Enemy") || hit.CompareTag("Boss"))
                    {
                        Enemy ally = hit.GetComponent<Enemy>();
                        if (ally != null && ally.getHealth() < ally.getMaxHealth())
                        {
                            StartCoroutine(HealTarget(ally));
                            break; // soigne un seul à la fois
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(1 / specialRoF);
        isSpecialShooting = false;
    }
    IEnumerator HealTanker()
    {
        Tanker.changeHealth(healAmmount, "add");
        yield return new WaitForSeconds(healDuration);
    }

    IEnumerator HealTarget(Enemy target)
    {
        Vector2 prevVelocity = rb.velocity;
        rb.velocity = Vector2.zero;
        isMoving = true;

        target.changeHealth(healAmmount, "add");

        yield return new WaitForSeconds(healDuration);

        rb.velocity = prevVelocity;
        isMoving = false;
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