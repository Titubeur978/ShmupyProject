using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileBehavior : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;
    public GameObject subProjectile;
    public Transform BSP1, BSP2, BSP3;

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
        StartCoroutine(SpecialEffect());
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Enemy>().changeHealth(1, "remove");
            Destroy(gameObject);
        }
    }

    IEnumerator SpecialEffect()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(subProjectile, BSP1);
        Instantiate(subProjectile, BSP2);
        Instantiate(subProjectile, BSP3);
    }

}
