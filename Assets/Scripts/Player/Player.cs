using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    protected int maxHealth, dmg;
    protected float speed, RoF; //RoF=shots per seconds
    protected bool isShooting = false;
    
    private int currentHealth;

    public GameObject projectile;
    public Transform shootPoint;


    [SerializeField] protected Rigidbody2D rb;
    private Vector2 move = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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
            setHealth(currentHealth + health);
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
