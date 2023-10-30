using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileBehavior : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;
    private int dmg;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0,15);
        dmg = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getDMG();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            other.gameObject.GetComponent<Enemy>().changeHealth(dmg, "remove");
            Destroy(gameObject);
        }
    }
}
