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
            other.gameObject.GetComponent<Player>().ReceiveShot(1);
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Wall")
            Destroy(gameObject);

        else if (other.tag == "ProjPlayer")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void SetVelocity()
    {
        float angle = transform.eulerAngles.z;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        rb.velocity = rotation * Vector2.down * 5;
    }
}
