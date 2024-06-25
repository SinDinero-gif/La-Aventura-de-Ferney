using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSound, playerSfxSound, enemySfxSound;
    public AudioSource musicSource, playerSfxSource, enemySfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic("Menu Music");
    }
    void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlayPlayerSFX(string name)
    {

        Sound s = Array.Find(playerSfxSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            playerSfxSource.clip = s.clip;
            playerSfxSource.Play();
        }

    }

    public void PlayEnemySFX(string name)
    {

        Sound s = Array.Find(enemySfxSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            enemySfxSource.clip = s.clip;
            enemySfxSource.Play();
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
