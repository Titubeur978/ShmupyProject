using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite shield2, shield3;
    public SpriteRenderer SR;
    private int HitsLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
