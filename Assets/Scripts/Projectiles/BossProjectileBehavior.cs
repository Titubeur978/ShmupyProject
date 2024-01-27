using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileBehavior : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;
    public GameObject subProjectile;
    public Transform BSP1, BSP2, BSP3;
    private bool scattered = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, -10);
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!scattered)
            StartCoroutine(SpecialEffect());
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().changeHealth(1, "remove");
            Destroy(gameObject);
        }
    }

    IEnumerator SpecialEffect()
    {
        scattered= true;
        yield return new WaitForSeconds(1.0f);

        GameObject subProjectile1 = Instantiate(subProjectile, BSP1.transform.position, BSP1.transform.rotation );
        GameObject subProjectile2 = Instantiate(subProjectile, BSP2.transform.position, BSP2.transform.rotation );
        GameObject subProjectile3 = Instantiate(subProjectile, BSP3.transform.position, BSP3.transform.rotation );
        Destroy(gameObject);
    }

}
