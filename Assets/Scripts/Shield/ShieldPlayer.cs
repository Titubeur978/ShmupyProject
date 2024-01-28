using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    public Sprite shield2, shield3;
    public SpriteRenderer SR;
    private int HitsLeft = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="ProjEnemy" || other.gameObject.tag == "ProjBoss")
        {
            OnDamaged();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<Enemy>().changeHealth(HitsLeft, "remove");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Shield")
        {
            Destroy(other.gameObject);
            OnDamaged();
        }
    }


    void OnDamaged()
    {
        HitsLeft--;
        if (HitsLeft==2)
        {
            SR.sprite = shield2;
        }
        else if (HitsLeft==1)
        {
            SR.sprite = shield3;
        }
        else
            Destroy(gameObject);
    }
}
