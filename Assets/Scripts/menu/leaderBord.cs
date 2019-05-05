using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderBord : MonoBehaviour
{
    public GameObject leader;
    public GameObject board;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        int i = 0;
        foreach (AllScores s in SaveManager.Instance.GetScores()) 
        {
            i++;
            GameObject score = (GameObject)Instantiate(leader);
            score.transform.SetParent(board.transform);

            score.transform.Find("Name").GetComponent<Text>().text = i + ". " + s.name;
            score.transform.Find("Score").GetComponent<Text>().text = s.score.ToString();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnExitClick()
    {
        foreach (Transform c in board.transform)
            GameObject.Destroy(c.gameObject);
        gameObject.SetActive(false);
    }
}
