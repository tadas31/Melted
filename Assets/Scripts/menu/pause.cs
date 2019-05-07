using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public void TaskOnBackToGameClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void TaskOnBackToMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TaskOnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
