using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRock : MonoBehaviour
{
    Animator myAnimationController;


    private void OnTriggerEnter(Collider other)
    {
        myAnimationController = GetComponent<Animator>();
        if (other.CompareTag("Bullet"))
            StartCoroutine(Shake());
           
        
    }

    IEnumerator Shake()
    {
        myAnimationController.SetBool("Shake", true);
        yield return new WaitForSeconds(0.5f);
        myAnimationController.SetBool("Shake", false);

    }


}
