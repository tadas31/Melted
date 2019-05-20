using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public Sound[] sounds;
    //public float duration;

    //public static AudioManager instance;

    //// Start is called before the first frame update
    //void Awake()
    //{
    //    if (instance == null)
    //        instance = this;
    //    else
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    DontDestroyOnLoad(gameObject);


    //    foreach(Sound s in sounds)
    //    {

    //        s.source = gameObject.AddComponent<AudioSource>();
    //        s.source.clip = s.clip;

    //        s.source.volume = s.volume;
    //        s.source.pitch = s.pitch;
    //        s.source.loop = s.loop;

    //        duration = s.source.clip.length;


    //        StartCoroutine(playSoundAfterTenSeconds());

    //        s.source.Play();
    //        s.source.PlayOneShot
    //    }
    //}



    //void Start()
    //{
    //    Play("Background");
    //    sounds[0].clip.
    //}

    //public void Play(string name)
    //{
    //    Sound s = Array.Find(sounds, sound => sound.name == name);

    //    s.source.Play();
    //}



    ////public void PlayBackground(string name)
    ////{
    ////    Sound s = Array.Find(sounds, sound => sound.name == name);

    ////    s.source.Play();
    ////}

    //IEnumerator playSoundAfterTenSeconds()
    //{
    //    yield return new WaitForSeconds(duration);

    //}

    public AudioSource adSource;
    public AudioClip[] adClips;

    public static AudioManager instance;

    

    private void Awake()
    {      
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        instance.adSource.volume = SaveManager.Instance.getMusicVolume(); 

        StartCoroutine(playAudioSequentially());
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < adClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            adSource.clip = adClips[i];

            //3.Play Audio
            adSource.Play();

            //4.Wait for it to finish playing
            while (adSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }
}
