using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : Player
{
    public Transform shootPoint2;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;
        speed = 10;
        RoF = 8;
        dmg = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Shoot()
    {
        StartCoroutine(Shooting(RoF));
    }

    IEnumerator Shooting(float RoF)
    {
        isShooting = true; 
        Instantiate(projectile, shootPoint);
        Instantiate(projectile, shootPoint2);
        yield return new WaitForSeconds(1/RoF);
        isShooting = false;
    }
}
