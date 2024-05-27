using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] protected int maxHealth, dmg;
    [SerializeField] private int currentHealth;
    [SerializeField] protected float speed, RoF; //RoF=shots per seconds

    protected bool isShooting = false;
    private bool first = true;

    public GameObject projectile;
    public Transform shootPoint;

    [SerializeField] protected Rigidbody2D rb;
    private Vector2 move = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (first)
        {
            currentHealth = maxHealth;
            first = false;
        }
        Move();
        if(getHealth() <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You Dead !");
        }
    }



    private void OnMove(InputValue val) //Listening player movement inputs (zqsd/wasd)
    {
        move = val.Get<Vector2>();
    }

    private void OnShoot()
    {
        if(!isShooting)
            Shoot();
    }

    private void OnBoost()
    {

    }

    private void Move()
    {
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime * speed); //moves according to OnMove actions
    }

    public virtual void Shoot()
    {
        StartCoroutine(Shooting(RoF));
    }



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
        else if (change == "remove")
            setHealth(currentHealth - health);
    }

    IEnumerator Shooting(float RoF)
    {
        isShooting = true;
        Instantiate(projectile, shootPoint);
        yield return new WaitForSeconds(1/RoF);
        isShooting = false;
    }

    public int getDMG() { return dmg; }


}
