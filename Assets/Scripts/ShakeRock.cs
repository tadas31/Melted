using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRock : MonoBehaviour
{
    Animator myAnimationController;
    Animator myAnimationControllerBarrel;


    private void OnTriggerEnter(Collider other)
    {
        myAnimationController = GetComponent<Animator>();
        myAnimationControllerBarrel = GetComponentInParent<Animator>();
        if (other.CompareTag("Bullet") && gameObject.name != "Barrel")      // Akmens judejimui
            StartCoroutine(Shake());
        if (other.CompareTag("Player") && gameObject.name == "Collider")    // Backos judejimui
            myAnimationControllerBarrel.SetBool("Shake", true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.name == "Collider")
            myAnimationControllerBarrel.SetBool("Shake", false);
    }

    IEnumerator Shake()
    {
        myAnimationController.SetBool("Shake", true);
        yield return new WaitForSeconds(0.5f);
        myAnimationController.SetBool("Shake", false);

    }


}
