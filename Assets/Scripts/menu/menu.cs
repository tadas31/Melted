using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Canvas about;
    public Canvas settings;
    public Canvas leaderBord;

    public void Awake()
    {
        AudioManager.instance.adSource.volume = SaveManager.Instance.getMusicVolume();
    }

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
        leaderBord.gameObject.SetActive(true);
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
