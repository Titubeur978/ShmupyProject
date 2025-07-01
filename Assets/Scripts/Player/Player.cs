using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    protected int health, dmg;
    protected float speed, RoF; 
    public EntityHealth healthComponent;

    protected bool isShooting = false;

    public GameObject projectile;
    public Transform shootPoint;

    [SerializeField] protected Rigidbody2D rb;
    private Vector2 move = Vector2.zero;

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
        Move(); //Puis écoute les instructions pour se déplacer
    }


    public void ReceiveShot(int damage)
    {
        healthComponent.ModifyHealth(damage, HealthChangeType.Remove);
    }

    public void ReceiveHeal(int heal)
    {
        healthComponent.ModifyHealth(heal, HealthChangeType.Add);
    }

    private void OnMove(InputValue val) //Listening player movement inputs (zqsd/wasd)
    {
        move = val.Get<Vector2>();
    }

    private void OnShoot() //Listening player shoot input (space)
    {
        if(!isShooting)
            Shoot();
    }

    private void OnBoost() //Listening player boost input (left shift)
    {
        //pas encore implémenté
    }



    private void Move()
    {
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime * speed); //moves according to OnMove actions
    }

    public virtual void Shoot()
    {
        StartCoroutine(Shooting(RoF));
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
