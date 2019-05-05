using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGruop;
    private float loadTime;
    private float minimumLogoTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        fadeGruop = FindObjectOfType<CanvasGroup>();

        fadeGruop.alpha = 1;
        if (Time.time < minimumLogoTime)
            loadTime = minimumLogoTime;
        else
            loadTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < minimumLogoTime)
        {
            fadeGruop.alpha = 1 - Time.time;
        }

        if (Time.time > minimumLogoTime && loadTime != 0)
        {
            fadeGruop.alpha = Time.time - minimumLogoTime;
            if (fadeGruop.alpha >= 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
