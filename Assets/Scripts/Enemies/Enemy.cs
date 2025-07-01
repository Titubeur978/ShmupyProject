using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int health,shootChance;
    protected float speed, RoF;
    private EntityHealth healthComponent;
    protected Vector2 mov;

    public int currentHealth;

    public GameObject projectile;
    public Transform shootPoint;

    protected bool isShooting,isMoving;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthComponent = GetComponent<EntityHealth>();
        if (healthComponent != null)
        {
            healthComponent.maxHealth = health;
            healthComponent.SetHealth(health);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isShooting)
            Shoot();

        if (!isMoving)
            Move();
    }

    public void ReceiveShot(int damage)
    {
        healthComponent.ModifyHealth(damage, HealthChangeType.Remove);
    }

    public void ReceiveHeal(int heal)
    {
        healthComponent.ModifyHealth(heal, HealthChangeType.Add);
    }

    public virtual void Move()
    {
        StartCoroutine(Moving());
    }

    public void DistanceToWall() //pas sur du retour, mais ca restera pas un void
    {
        //verifier quel mur est le plus proche et s'il est trop proche, empecher le deplacement dans cette direction
        //vitesse * temps entre déplacement = distance du prochain déplacement
    }



    public virtual void Shoot()
    {
        StartCoroutine(Shooting(RoF));
    }

    public virtual IEnumerator Moving()
    {
        isMoving = true;
        int rng = Random.Range(0, 4);
        switch (rng)
        {
            case 0:
                mov = Vector2.up;
                break;

            case 1:
                mov = Vector2.right;
                break;

            case 2:
                mov = Vector2.down;
                break;

            case 3:
                mov = Vector2.left;
                break;
        }
        rb.velocity = mov * speed;
        yield return new WaitForSeconds(2 / speed);
        isMoving = false;
    }

    IEnumerator Shooting(float RoF)
    {
        isShooting = true;
        int rng = Random.Range(0, 100);
        if (rng > (100-shootChance))
            Instantiate(projectile, shootPoint);
        yield return new WaitForSeconds(1 / RoF);
        isShooting = false;
    }
}
