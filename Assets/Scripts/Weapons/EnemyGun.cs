using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public bool isFiring = true;

    public EnemyBulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotsTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotsTimer -= Time.deltaTime;
            if (shotsTimer <= 0)
            {
                shotsTimer -= Time.deltaTime;
                if (shotsTimer <= 0)
                {
                    shotsTimer = timeBetweenShots;
                    EnemyBulletController newBullet = Instantiate(bullet, transform.position, transform.rotation) as EnemyBulletController;
                    newBullet.speed = bulletSpeed;
                }
            }
        }
        else
        {
            if (shotsTimer > 0)
                shotsTimer -= Time.deltaTime;
        }
    }
}
