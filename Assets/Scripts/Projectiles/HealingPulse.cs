using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPulse : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;
    private int heal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<Enemy>().changeHealth(heal, "add");
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
            Destroy(gameObject);
        else if (other.tag == "ProjPlayer")
            Destroy(gameObject);
    }
}
