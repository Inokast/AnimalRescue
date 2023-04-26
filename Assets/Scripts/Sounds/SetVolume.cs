using UnityEngine;
using UnityEngine.Audio;

//Assignment/Lab/Project: GameJuice Project
//Name: Daniel Sanchez

public class SetVolume : MonoBehaviour
{
    public AudioMixer bgmMixer;
    public AudioMixer sfxMixer;

    public void SetMusicLevel(float sliderValue)
    {
        //parameters use exposed parameter from Unity and mathf.Log10 to convert from linear to logarithmic, then multiplied times 20
        bgmMixer.SetFloat("bgmMixer", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSoundLevel(float sliderValue)
    {
        //parameters use exposed parameter from Unity and mathf.Log10 to convert from linear to logarithmic, then multiplied times 20
        sfxMixer.SetFloat("sfxMixer", Mathf.Log10(sliderValue) * 20);
    }
}