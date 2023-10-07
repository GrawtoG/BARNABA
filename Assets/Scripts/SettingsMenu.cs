using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer musicMixer;
    public AudioMixer soundMixer;


    public void SetMusicVolume(float music_volume)
    {
        musicMixer.SetFloat("music_volume", music_volume);
            
    }

    public void SetSoundsVolume(float sounds_volume)
    {
        soundMixer.SetFloat("sounds_volume", sounds_volume);

    }



    public void SetQuality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    
    
    }

}
