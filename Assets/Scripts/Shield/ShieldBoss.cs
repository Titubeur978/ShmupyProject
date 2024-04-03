using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoss : MonoBehaviour
{
    public SpriteRenderer SR;
    public GameObject Shield2nd;

    private Vector4 transp = new Vector4(1f, .75f, .75f, .75f);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ProjPlayer")
        {
            SR.color *= transp;
            if (SR.color.a < 0.25f)
            {
                Shield2nd.SetActive(true);
                Destroy(gameObject); 
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().changeHealth(2, "remove");
        }
    }
}
