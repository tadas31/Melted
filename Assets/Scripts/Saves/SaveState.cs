using System;
using UnityEngine;

public class SaveState
{
    public AllScores[] Score = { new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0),
    new AllScores("N/A", 0) };


    public KeyBindings[] buttonNames = { new KeyBindings("up", KeyCode.W),
        new KeyBindings("down", KeyCode.S),
        new KeyBindings("left", KeyCode.A ),
        new KeyBindings("right",KeyCode.D),
        new KeyBindings("fire", KeyCode.Mouse0) };


}

public class KeyBindings
{
    public string keyName { get; set; }
    public KeyCode code { get; set; }

   public KeyBindings(){    }

    public KeyBindings(string keyName, KeyCode code)
    {
        this.keyName = keyName;
        this.code = code;
    }
}

public class AllScores : IComparable
{
    public string name { get; set; }
    public int score { get; set; }

    public AllScores() { }

    public AllScores(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public int CompareTo(object obj)
    {
        AllScores otherProbability = obj as AllScores;
        return -score.CompareTo(otherProbability.score);
    }

}
