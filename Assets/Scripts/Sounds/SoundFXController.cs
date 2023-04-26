using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : MonoBehaviour
{
    private AudioSource[] soundFX;

    private AudioSource collectStar;
    private AudioSource collectKey;
    private AudioSource bounce;
    private AudioSource thunk;
    private AudioSource launch;
    private AudioSource menuClick;
    private AudioSource unlock;

    private void Start()
    {
        soundFX = GetComponents<AudioSource>();

        collectStar = soundFX[0];
        collectKey = soundFX[1];
        bounce = soundFX[2];
        thunk = soundFX[3];
        launch = soundFX[4];
        menuClick = soundFX[5];
        unlock = soundFX[6];
    }

    public void PlayCollectStar()
    {
        collectStar.Play();
    }

    public void PlayCollectKey()
    {
        collectKey.Play();
    }

    public void PlayBounce()
    {
        bounce.Play();
    }

    public void PlayThunk()
    {
        thunk.Play();
    }

    public void PlayLaunch()
    {
        launch.Play();
    }

    public void PlayMenuClick()
    {
        menuClick.Play();
    }

    public void PlayUnlock()
    {
        unlock.Play();
    }

}
