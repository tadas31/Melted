using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class worldSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void TaskOnWorldOneClick()
    {
        SceneManager.LoadScene("World1");
    }
    public void TaskOnWorldTwoClick()
    {
        SceneManager.LoadScene("World2");
    }
    public void TaskOnWorldThreeClick()
    {
        SceneManager.LoadScene("World3");
    }

    public void TaskOnBackClick()
    {
        SceneManager.LoadScene("Menu");
    }


}
