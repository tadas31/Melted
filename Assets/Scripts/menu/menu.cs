using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Canvas about;
    public Canvas settings;

     public void TaskOnPlayClick()
    {
        SceneManager.LoadScene("WorldSelection");
    }

    public void TaskOnSettingsClick()
    {
        settings.gameObject.SetActive(true);
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
