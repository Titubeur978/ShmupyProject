using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : Player
{
    // Start is called before the first frame update
    protected override void Start()
    {
        health = 7;
        speed = 10;
        RoF = 6;
        dmg = 2;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
