using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    static public BGMController M;

   public AudioSource menuMusic;
   public AudioSource levelMusic;
   public AudioSource victoryMusic;
   public AudioSource powerupMusic;

    void Awake()
    {
        if (M == null)
        {
            DontDestroyOnLoad(gameObject);
            M = this;
        }
        else if (M != null)
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayLevelMusic()
    {
        StopMusic();
        levelMusic.Play();
    }

    public void PlayVictoryMusic()
    {
        StopMusic();
        victoryMusic.Play();
    }

    public void PlayPowerupyMusic()
    {
        StopMusic();
        powerupMusic.Play();
    }

    public void StopMusic()
    {
        menuMusic.Stop();
        levelMusic.Stop();
        victoryMusic.Stop();
        powerupMusic.Stop();
    }
}
