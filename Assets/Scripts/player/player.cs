﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player : MonoBehaviour
{
    public static player Instance { set; get; }


    public float moveSpeed;
    public int health = 100;
    private int currHealth;

    public event Action<float, float> OnHealthPctChanged = delegate { };
    public PlayerGun theGun;

    public GameObject spawnPoints;
    private Transform[] arrayOfspawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        arrayOfspawnPoints = spawnPoints.GetComponentsInChildren<Transform>();
        System.Random rand = new System.Random();
        int point = rand.Next(0, arrayOfspawnPoints.Length);
        gameObject.transform.position = arrayOfspawnPoints[point].position;

        Instance = this;
        currHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;


        if (Input.GetKeyDown(KeyCode.KeypadMinus))
            Damage(10);
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            Heal(10, 0f);

       

    }

    public void Damage(int amount)
    {
        currHealth -= amount;
        float currentHealthPct = (float)currHealth / (float)health;
        OnHealthPctChanged(currentHealthPct, 0.5f);
    }

    public void Heal(int amount, float speed)
    {
        currHealth += amount;
        float currentHealthPct = (float)currHealth / (float)health;
        OnHealthPctChanged(currentHealthPct, speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Log")
        {
            Heal(15, 0.5f);
        }
        
    }
}
