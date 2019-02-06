using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

     public void TaskOnPlayClick()
    {
        SceneManager.LoadScene("WorldSelection");
    }

    public void TaskOnExitClick()
    {
        Application.Quit();
    }
}
