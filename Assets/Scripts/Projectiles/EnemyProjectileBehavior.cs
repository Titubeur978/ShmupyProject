using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehavior : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, -15);
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Enemy>().changeHealth(1, "remove");
            Destroy(gameObject);
        }
    }
}
