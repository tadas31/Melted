using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        CharacterTrack.Instance._player.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enviroment" || other.tag == "Ground")
        {
            Destroy(gameObject, 0.3f);
            CharacterTrack.Instance._player.Remove(gameObject.transform);
        }
        
        if (other.tag == "Enemy")
        {
            //do damage to enemy and disapear
        }
    }
}
