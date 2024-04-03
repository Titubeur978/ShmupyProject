using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSubProjecile : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetVelocity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().changeHealth(1, "remove");
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
            Destroy(gameObject);
    }

    void SetVelocity()
    {
        float angle = transform.eulerAngles.z;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        rb.velocity = rotation * Vector2.down * 5;
    }
}
