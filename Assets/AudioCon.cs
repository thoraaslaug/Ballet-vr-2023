using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCon : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    private void Start()
    {
        audioSource3.Play();
    }

    public void PlaySound()
    {
        if (audioSource1 != null && audioSource2 !=null)
        {
            audioSource1.Play();
            audioSource2.Play();
            audioSource3.Stop();
        }
    }
}
