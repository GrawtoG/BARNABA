using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public AudioSource _musicSource;
    public AudioSource _effectSource;
    private void Awake()
    { 
        
        DontDestroyOnLoad(this);
    }


    void Update()
    {

    }


    public void PlaySound(AudioClip _clip)
    {
        _effectSource.PlayOneShot(_clip);
    }
}
