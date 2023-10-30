using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavy : Player
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10;
        speed = 5;
        RoF = 3;
        dmg = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
