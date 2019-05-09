using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    private Canvas pauseCanvas;
    private Canvas gameOver;
    private Text scoreText;
    private Text gameOverScoreText;

    private float score;

    private inputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindObjectOfType<inputManager>();
        Time.timeScale = 1;
        score = 0;
        pauseCanvas = GameObject.Find("Pause").GetComponent<Canvas>();
        pauseCanvas.gameObject.SetActive(false);

        gameOver = GameObject.Find("GameOver").GetComponent<Canvas>();
        gameOverScoreText = GameObject.Find("GameOver/Score").GetComponent<Text>();
        gameOver.gameObject.SetActive(false);

        scoreText = GameObject.Find("GameUI/Score").GetComponent<Text>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        Score();

        if (inputManager.GetButton("pause") && player.Instance.GetHealth() > 0)
            PauseGame();

        if (player.Instance.GetHealth() <= 0)
            GameOver();

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
        gameOverScoreText.text = "Your score: " + (int)score;
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
    }

    void Score()
    {
        score += Time.deltaTime;

        scoreText.text = "Score: " + (int)score;
    }

    public void addScoreOnKill()
    {
        score += 100;
    }

    public int GetScore()
    {
        return (int)score;
    }
}
