using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnLog : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        gameObject.GetComponent<Animator>().StartPlayback();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(DestroyObject());
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            gameObject.GetComponent<Animator>().StopPlayback();
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
