using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampFire : MonoBehaviour
{
    public Text interact;

    private bool isByFire;
    private bool isFireLit;

    private inputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        isByFire = false;
        isFireLit = false;

        inputManager = GameObject.FindObjectOfType<inputManager>();
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {



        if (isByFire && isFireLit  && player.Instance.GetHealth() <= 100)
            player.Instance.Damage(-1f * Time.deltaTime);

        if (!isFireLit && isByFire && inputManager.GetButtonDown("interact"))
        {
            isFireLit = true;
            interact.gameObject.SetActive(false);

            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            CharacterTrack.Instance._player.Add(gameObject.transform);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isFireLit)
        {
            isByFire = true;
            interact.gameObject.SetActive(true);
            interact.text = "Press " + SaveManager.Instance.getKeyBindings()[4].code.ToString() + " to light fire";
        }
        else if (other.tag == "Player")
        {
            isByFire = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isFireLit)
        {
            isByFire = false;
            interact.gameObject.SetActive(false);
        }
        if (other.tag == "Player")
        {
            isByFire = false;
        }
    }
}
