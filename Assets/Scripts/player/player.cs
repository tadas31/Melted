using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player : MonoBehaviour
{
    public float moveSpeed;
    public int health = 100;
    private int currHealth;

    public event Action<float, float> OnHealthPctChanged = delegate { };


    private void Start()
    {

        currHealth = health;

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

    private void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
            Damage(10);
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            Heal(10,0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Log")
        {
            Heal(15, 0.5f);
            Debug.Log(other.name);
        }
        
    }
}
