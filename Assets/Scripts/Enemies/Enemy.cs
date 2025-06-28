using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int maxHealth, shootChance;
    [SerializeField] protected float speed, RoF;
    protected Vector2 mov;

    public int currentHealth;

    public GameObject projectile;
    public Transform shootPoint;

    protected bool isShooting,isMoving;

    protected Rigidbody2D rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);

        if (!isShooting)
            Shoot();

        if (!isMoving)
            Move();
    }

    public virtual void Move()
    {
        StartCoroutine(Moving());
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
        yield return new WaitForSeconds(2/speed);
        isMoving = false;
    }

    public virtual void Shoot()
    {
        StartCoroutine(Shooting(RoF));
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

    public void DistanceToWall() //pas sur du retour, mais ca restera pas un void
    {
        //verifier quel mur est le plus proche et s'il est trop proche, empecher le deplacement dans cette direction
    }

    public int getMaxHealth() { return maxHealth; }
    public int getHealth() { return currentHealth; }
    public void setHealth(int health) { currentHealth = health; }
    public void changeHealth(int health, string change)
    {
        if (change == "add")
        {
            if (currentHealth + health <= maxHealth)
                currentHealth += health;
            else
                currentHealth = maxHealth;
        }
        else if( change == "remove")
            setHealth(currentHealth - health);
    }


}
