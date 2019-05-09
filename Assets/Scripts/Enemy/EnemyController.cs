using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    EnemyGun gun;

    public float health = 100;
    private float currHealth;

    public event Action<float, float> OnHealthPctChanged = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.instance.respawned = true;
        currHealth = health;
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        gun = GetComponent<EnemyGun>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            gun.isFiring = true;
        }
        else gun.isFiring = false;
    }

    public void Damage(float amount)
    {
        currHealth -= amount;
        float currentHealthPct = (float)currHealth / (float)health;
        OnHealthPctChanged(currentHealthPct, 0.5f);
    }
}
