using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

     public void TaskOnPlayClick()
    {
        SceneManager.LoadScene("WorldSelection");
    }

    public void TaskOnExitClick()
    {
        Application.Quit();
    }
}
