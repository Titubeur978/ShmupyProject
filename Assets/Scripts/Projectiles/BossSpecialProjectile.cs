using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialProjectile : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;
    private bool explosion = false;
    private float explosionRadius = 3f;
    private float distance;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, -5);
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= explosionRadius/2)
        {
            player.GetComponent<Player>().changeHealth(2, "remove");
            //jouer l'explosion en plus petite
            Destroy(gameObject);
        }

        if (!explosion)
            StartCoroutine(SpecialEffect());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().changeHealth(4, "remove");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "ProjPlayer")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator SpecialEffect()
    {
        int duree = Random.Range(5, 8);
        explosion = true;
        yield return new WaitForSeconds(0.5f*duree);
        if (distance <= explosionRadius)
            player.GetComponent<Player>().changeHealth(3, "remove");
        //jouer l'explosion
        Destroy(gameObject);

    }
}
