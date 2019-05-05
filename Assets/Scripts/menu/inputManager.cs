using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class inputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonNames;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        buttonNames = new Dictionary<string, KeyCode>();


        //--------------read from saves file-----------------
        buttonNames["up"] = KeyCode.W;
        buttonNames["down"] = KeyCode.S;
        buttonNames["left"] = KeyCode.A;
        buttonNames["right"] = KeyCode.D;
        buttonNames["fire"] = KeyCode.Mouse0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetButtonDown(string buttonName)
    {
        if (buttonNames.ContainsKey(buttonName) == false)
            return false;

        return Input.GetKeyDown(buttonNames[buttonName]);
    }

    public bool GetButtonUp(string buttonName)
    {
        if (buttonNames.ContainsKey(buttonName) == false)
            return false;

        return Input.GetKeyUp(buttonNames[buttonName]);
    }
    public bool GetButton(string buttonName)
    {
        if (buttonNames.ContainsKey(buttonName) == false)
            return false;

        return Input.GetKey(buttonNames[buttonName]);
    }


    public string[] GetButtonNames()
    {
        return buttonNames.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if (buttonNames.ContainsKey(buttonName) == false)
            return "N/A";

        return buttonNames[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        buttonNames[buttonName] = keyCode;
    }
}
