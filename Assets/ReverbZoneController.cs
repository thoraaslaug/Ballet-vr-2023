using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioReverbZone reverbZone;
    public float duration = 5f; // Duration in seconds before stopping the reverb zone and music

    private bool isPlaying = false;

    void Start()
    {
        if (musicAudioSource == null || reverbZone == null)
        {
            Debug.LogError("Audio Source or Reverb Zone components not assigned!");
        }
    }

    void Update()
    {
        if (isPlaying)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                StopAudio();
            }
        }
    }

    public void PlayAudioWithReverb()
    {
        if (musicAudioSource != null && reverbZone != null)
        {
            musicAudioSource.Play();
            reverbZone.enabled = true;
            isPlaying = true;
            duration = 5f; // Reset duration when starting the audio
        }
    }

    public void StopAudio()
    {
        if (musicAudioSource != null && reverbZone != null)
        {
            musicAudioSource.Stop();
            reverbZone.enabled = false;
            isPlaying = false;
        }
    }
}