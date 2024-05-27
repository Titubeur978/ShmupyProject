using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    private SpriteRenderer SR;
    Vector4 transp = new Vector4(1f, .75f, .75f, .5f);

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ProjPlayer")
        {
            SR.color *= transp; 
            if (SR.color.a < 0.2f)
                Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().changeHealth(2, "remove");
        }
    }
}
