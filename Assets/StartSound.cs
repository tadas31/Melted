using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
           // FindObjectOfType<AudioManager>().Play("Fireplace");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            GetComponent<AudioSource>().Stop();
    }
}
