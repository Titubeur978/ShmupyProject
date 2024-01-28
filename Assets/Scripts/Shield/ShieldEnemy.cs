using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ProjPlayer")
        {
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
