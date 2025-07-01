using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTanker : Enemy
{
    public Transform ShieldPoint;
    public EnemyMedic Medic;

    protected override void Start()
    {
        health = 15;
        speed = 5;
        RoF = 3;
        shootChance = 20;
        base.Start();
    }

    public override void Move()
    {
        StartCoroutine(Moving());
    }

    public override IEnumerator Moving()
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
        if(Medic != null)
            Medic.SetVel(mov);
        yield return new WaitForSeconds(2 / speed);
        isMoving = false;
    }

}
