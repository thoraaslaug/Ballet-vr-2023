using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForTwo : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip1; 
    public AudioClip audioClip2;

    public void PlayAudioClip1()
    {
        // Set the audio clip for the AudioSource and play it
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void PlayAudioClip2()
    {
        // Set the audio clip for the AudioSource and play it
        audioSource.clip = audioClip2;
        audioSource.Play();
        
    }
}
