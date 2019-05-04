using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Canvas about;

     public void TaskOnPlayClick()
    {
        SceneManager.LoadScene("WorldSelection");
    }

    public void TaskOnSettingsClick()
    {

    }

    public void TaskOnLeaderBordsClick()
    {

    }

    public void TaskOnAboutClick()
    {
        about.gameObject.SetActive(true);
    }

    public void TaskOnExitClick()
    {
        Application.Quit();
    }
}
