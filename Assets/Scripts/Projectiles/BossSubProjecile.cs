using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSubProjeciles : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, -20);
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
