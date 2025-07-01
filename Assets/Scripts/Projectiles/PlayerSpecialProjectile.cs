using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialProjectile : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;
    private int dmg;
    private bool explosion, accel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, 5);
        dmg = 5;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
        /*if (!explosion)
            StartCoroutine(SpecialEffect());*/
        if (!accel)
            StartCoroutine(Acceleration());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<Enemy>().ReceiveShot(dmg);
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Wall")
            Destroy(gameObject);

        else if (other.tag == "ProjBoss" || other.tag == "ProjEnemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator SpecialEffect()
    {
        int duree = Random.Range(5, 8);
        explosion = true;
        yield return new WaitForSeconds(0.5f * duree);
        /*if (distance <= explosionRadius)
            player.GetComponent<Player>().changeHealth(3, "remove");*/
        //jouer l'explosion
        Destroy(gameObject);

    }

    IEnumerator Acceleration()
    {
        speed = speed * 1.01f;
        yield return new WaitForSeconds(0.5f);
    }
}
