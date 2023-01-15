using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;
   // [SerializeField] private AudioListener volume;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
       // volume = GetComponent<AudioListener>();
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
    //public void VolumeSound(AudioListener _volume)
    //{
    //    volume = _volume;
    //}
}
