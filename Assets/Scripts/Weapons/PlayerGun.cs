using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
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
                shotsTimer = timeBetweenShots;
                BulletController newBullet =  Instantiate(bullet, transform.position, transform.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }

        else
        {
            shotsTimer = 0;
        }
    }
}
