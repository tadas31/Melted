using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public static enemy Instance { get; set; }

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    EnemyGun gun;

    public float health = 100;
    private float currHealth;
    private float moveSpeed = 5f;
    private float rotSpeed = 200;
    private float angularSpeed;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private bool isChasing = false;

    public event Action<float, float> OnHealthPctChanged = delegate { };

    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.instance.respawned = true;
        currHealth = health;
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        gun = GetComponent<EnemyGun>();
        transform.Find("EnemyHealthBar").gameObject.SetActive(false);
        angularSpeed = agent.angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            gun.isFiring = true;
            if (distance <= agent.stoppingDistance)
                FaceTarget();
            
            isChasing = true;
        }
        else
        {
            
            gun.isFiring = false;
            isChasing = false;           
        }
        if(distance <= lookRadius + 5)
            transform.Find("EnemyHealthBar").gameObject.SetActive(true);
        else
            transform.Find("EnemyHealthBar").gameObject.SetActive(false);

        if (currHealth <= 0)
        {
            GameManager.Instance.addScoreOnKill();
            Destroy(gameObject);           
            EnemyManager.instance.enemies = EnemyManager.instance.enemies.Where(val => val != gameObject).ToArray();
        }

        

        if (isChasing == false)
            WanderingStuff();

    }

    public void WanderingStuff()
    {
        if (isWandering == false)
            StartCoroutine(Wander());

        if (isRotatingRight == true)
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        if (isRotatingLeft == true)
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);

        if (isWalking == true)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    IEnumerator Wander()
    {
        int rotTime = UnityEngine.Random.Range(1,3);
        int rotateWait = UnityEngine.Random.Range(1, 3);
        int rotateLorR = UnityEngine.Random.Range(1, 2);
        int walkWait = UnityEngine.Random.Range(1, 3);
        int walkTime = UnityEngine.Random.Range(3, 8);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if(rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, Time.deltaTime * 5f);
    }

    public void Damage(float amount)
    {
        currHealth -= amount;
        float currentHealthPct = (float)currHealth / (float)health;
        OnHealthPctChanged(currentHealthPct, 0.5f);
    }
}
