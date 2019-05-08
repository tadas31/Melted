using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    private Slider musicVolume;
    private Slider effectsVolume;
    // Start is called before the first frame update
    void Start()
    {
        musicVolume = GameObject.Find("Music").GetComponent<Slider>();
        musicVolume.value = SaveManager.Instance.getMusicVolume();

        effectsVolume = GameObject.Find("Effects").GetComponent<Slider>();
        effectsVolume.value = SaveManager.Instance.getEffectsVolume();
    }

    // Update is called once per frame
    void Update()
    {

        SaveManager.Instance.setMusicVolume(musicVolume.value);
        AudioManager.instance.adSource.volume = musicVolume.value;

        SaveManager.Instance.setEffectsVolume(effectsVolume.value);
       
    }

    public void TaskOnExitClick()
    {
        gameObject.SetActive(false);
    }
}
