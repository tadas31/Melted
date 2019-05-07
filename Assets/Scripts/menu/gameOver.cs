using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{

    private InputField name;

    // Start is called before the first frame update
    void Start()
    {
        name = GameObject.Find("Name").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnMenuClick()
    {
        if (name.text == null || name.text == "")
            SaveManager.Instance.SetScore("Name", GameManager.Instance.GetScore());
        else
            SaveManager.Instance.SetScore(name.text, GameManager.Instance.GetScore());
        SceneManager.LoadScene("Menu");
    }

    public void TaskOnRestartClick()
    {
        if (name.text == null || name.text == "")
            SaveManager.Instance.SetScore("Name", GameManager.Instance.GetScore());
        else
            SaveManager.Instance.SetScore(name.text, GameManager.Instance.GetScore());


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
