using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] clips;
    public void Play(int id){
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clips[id];
        audio.Play();
    }
}
