using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : MonoBehaviour
{

    [Header("UI Sounds")]
    [SerializeField] private AudioSource select;
    [SerializeField] private AudioSource loadingLevel;
    [SerializeField] private AudioSource failure;
    [SerializeField] private AudioSource levelCompleted;


    [Header("Player Sounds")]
    [SerializeField] private AudioSource lashOn;
    [SerializeField] private AudioSource lashOff;
    [SerializeField] private AudioSource animalSecured;

    [Header("Animal Sounds")]
    [SerializeField] private AudioSource dogSound;
    [SerializeField] private AudioSource cowSound;
    [SerializeField] private AudioSource birdSound;
    [SerializeField] private AudioSource elephantSound;
    [SerializeField] private AudioSource frogSound;

    [Header("Impact Sounds")]
    [SerializeField] private AudioSource glassHit;
    [SerializeField] private AudioSource glassBreak;
    [SerializeField] private AudioSource thudHit;
    [SerializeField] private AudioSource woodBreak;
    [SerializeField] private AudioSource stoneBreak;
    [SerializeField] private AudioSource metalHit;
    [SerializeField] private AudioSource metalBreak;




    public void PlaySelect()
    {
        select.Play();
    }

    public void PlayLoadingLevel()
    {
        loadingLevel.Play();
    }

    public void PlayFailure()
    {
        failure.Play();
    }

    public void PlayLevelCompleted()
    {
        levelCompleted.Play();
    }

    public void PlayLashOn()
    {
        lashOn.Play();
    }

    public void PlayLashOff()
    {
        lashOff.Play();
    }

    public void PlayAnimalSecured()
    {
        animalSecured.Play();
    }

    public void PlayDogSound()
    {
        dogSound.Play();
    }

    public void PlayCowSound()
    {
        cowSound.Play();
    }

    public void PlayBirdSound()
    {
        birdSound.Play();
    }

    public void PlayElephantSound()
    {
        elephantSound.Play();
    }

    public void PlayFrogSound()
    {
        frogSound.Play();
    }
    public void PlayGlassHit()
    {
        glassHit.Play();
    }

    public void PlayGlassBreak()
    {
        glassBreak.Play();
    }

    public void PlayThudHit()
    {
        thudHit.Play();
    }

    public void PlayWoodBreak()
    {
        woodBreak.Play();
    }

    public void PlayStoneBreak()
    {
        stoneBreak.Play();
    }

    public void PlayMetalHit()
    {
        metalHit.Play();
    }
    public void PlayMetalBreak()
    {
        metalBreak.Play();
    }



}
