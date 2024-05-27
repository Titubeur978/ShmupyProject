using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : Player
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 6;
        speed = 10;
        RoF = 6;
        dmg = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
