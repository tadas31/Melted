using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class keyBindDialog : MonoBehaviour
{
    public GameObject key;
    public GameObject keys;
    public GameObject selectKeyPanel;
    public Button exitButton;

    private inputManager inputManager;

    string buttonToRebind;
    Dictionary<string, Text> buttonToLabel;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindObjectOfType<inputManager>();
        string[] buttonNames = inputManager.GetButtonNames();
        buttonToLabel = new Dictionary<string, Text>();

        foreach (string b in buttonNames)
        {
            GameObject binding = (GameObject)Instantiate(key);
            binding.transform.SetParent(keys.transform);
            
            binding.transform.Find("Name").GetComponent<Text>().text = b;

            binding.transform.Find("Button/KeyName").GetComponent<Text>().text = inputManager.GetKeyNameForButton(b);
            buttonToLabel[b] = binding.transform.Find("Button/KeyName").GetComponent<Text>();

            binding.transform.Find("Button").GetComponent<Button>().onClick.AddListener( () => { StartRebind(b); } );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonToRebind != null)
        {
            if (Input.anyKeyDown)
            {
                foreach(KeyCode c in Enum.GetValues(typeof(KeyCode)) )
                {
                    if (Input.GetKeyDown(c))
                    {
                        inputManager.SetButtonForKey(buttonToRebind, c);
                        buttonToLabel[buttonToRebind].text = c.ToString();
                        selectKeyPanel.SetActive(false);
                        exitButton.enabled = true;
                        buttonToRebind = null;
                        break;
                    }
                }
            }
        }
    }

    void StartRebind(string buttonName)
    {
        exitButton.enabled = false;
        selectKeyPanel.SetActive(true);
        buttonToRebind = buttonName;
    }
}
