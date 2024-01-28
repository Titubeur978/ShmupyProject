using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : Player
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        speed = 7;
        RoF = 4;
        dmg = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
