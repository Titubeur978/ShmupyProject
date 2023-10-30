using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int maxHealth, shootChance;
    protected float speed, RoF;

    public int currentHealth;

    public GameObject projectile;
    public Transform shootPoint;

    private bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth= maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (!isShooting)
        {
            Shoot();
        }
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
        {
            Instantiate(projectile, shootPoint);
        }
        yield return new WaitForSeconds(1 / RoF);
        isShooting = false;
    }

    public int getHealth() { return currentHealth; }
    public void setHealth(int health) { currentHealth = health; }
    public void changeHealth(int health, string change)
    {
        if (change == "add")
            setHealth(currentHealth + health);
        else if( change == "remove")
            setHealth(currentHealth - health);
    }
}
