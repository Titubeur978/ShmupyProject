using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    public Sprite shield2, shield3;
    private SpriteRenderer SR;
    private int HitsLeft = 3;
    private bool hitCD = false;
    Vector4 transp = new Vector4(1f, 1f, 1f, .5f);

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ProjEnemy" || other.gameObject.tag == "ProjBoss")
        {
            OnDamaged();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
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

    public virtual void OnDamaged()
    {
        if (!hitCD)
        {
            hitCD = true;
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        SR.color *= transp;
        HitsLeft--;
        yield return new WaitForSeconds(1.5f);
        hitCD = false;
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
