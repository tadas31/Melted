using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;
    public Transform firePos;

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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Plane ground = new Plane(Vector3.up, Vector3.zero);
                float rayLength;
                if(ground.Raycast(ray, out rayLength))
                {
                    Vector3 pointToLook = ray.GetPoint(rayLength);
                    firePos.LookAt(new Vector3(pointToLook.x, 1, pointToLook.z));
                }

                player.Instance.Damage(5);

                BulletController newBullet = Instantiate(bullet, firePos.position, firePos.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            if (shotsTimer > 0)
                shotsTimer -= Time.deltaTime;
        }
    }
}
