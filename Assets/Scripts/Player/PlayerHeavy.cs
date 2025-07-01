using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavy : Player
{
    // Start is called before the first frame update
    protected override void Start()
    {
        health = 12;
        speed = 7;
        RoF = 6;
        dmg = 3;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
