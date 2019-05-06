using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Canvas pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = GameObject.Find("Pause").GetComponent<Canvas>();
        pauseCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }


    void PauseGame()
    {
        if (pauseCanvas.gameObject.activeSelf)
        {
            pauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void GameOver()
    {
        if (player.Instance.health <= 0)
        {

            Time.timeScale = 0;
        }
    }
}
