using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SHOOT");
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        if (other.tag == "Enviroment" || other.tag == "Ground")
        {
            Destroy(gameObject, 0.3f);
            CharacterTrack.Instance._player.Remove(gameObject.transform);
        }

        if (other.tag == "Player")
        {
            
            Destroy(gameObject, 0.3f);
            CharacterTrack.Instance._player.Remove(gameObject.transform);
            player.Instance.Damage(5f);
            //do damage to enemy and disapear
        }
    }
}
