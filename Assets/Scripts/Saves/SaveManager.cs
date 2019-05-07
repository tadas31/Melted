using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; set; }
    public SaveState state;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        //ResetSave();
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", SaveHelper.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = SaveHelper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
        }
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }

    public void setKeyBinding(string keyName, KeyCode keyCode)
    {
        for (int i = 0; i < state.buttonNames.Length; i++)
            if (state.buttonNames[i].keyName == keyName)
                state.buttonNames[i].code = keyCode;

        Save();
    }

    public KeyBindings[] getKeyBindings()
    {
        return state.buttonNames;
    }

    public void SetScore(string name, int score)
    {
        if (state.Score[0].score == 0)
        {
            state.Score[0].name = name;
            state.Score[0].score = score;
        }
        else
        {
            List<AllScores> scores = new List<AllScores>();
            foreach (AllScores s in state.Score)
                scores.Add(s);

            scores.Add(new AllScores(name, score));
            scores.Sort();
            scores.RemoveAt(scores.Count-1);
            state.Score = scores.ToArray();
            scores.Clear();
        }

        Save();
    }



    public AllScores[] GetScores()
    {
        return state.Score;
    }
}
