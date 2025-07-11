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
}
