﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jesus : MonoBehaviour
{
    public PlayerGun theGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
    }
}
