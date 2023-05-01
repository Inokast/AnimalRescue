using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    static public BGMController M;

   public AudioSource menuMusic;
   public AudioSource world1Music;
   public AudioSource world2Music;
   public AudioSource world3Music;

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

    public void PlayMusicWithID(int songID) 
    {
        switch (songID)
        {
            case 0:
                PlayMenuMusic();
                break;

            case 1: PlayWorld1Music();
                break;

            case 2:
                PlayWorld2Music();
                break;

            case 3:
                PlayWorld3Music();
                break;


            default:
                PlayMenuMusic();
                break;
        }
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayWorld1Music()
    {
        StopMusic();
        world1Music.Play();
    }

    public void PlayWorld2Music()
    {
        StopMusic();
        world2Music.Play();
    }

    public void PlayWorld3Music()
    {
        StopMusic();
        world3Music.Play();
    }

    public void StopMusic()
    {
        menuMusic.Stop();
        world1Music.Stop();
        world2Music.Stop();
        world3Music.Stop();
    }
}
