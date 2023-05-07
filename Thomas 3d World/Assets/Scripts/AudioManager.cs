using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip rock;
    AudioSource audioPlayer;
    public AudioMixer mixer;

    private void Awake()
    {
        if (instance == null)
        {
            audioPlayer = GetComponent<AudioSource>();
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        audioPlayer.Play();
    }

    public void PlaySound(AudioClip audio, float volume)
    {
        audioPlayer.PlayOneShot(audio, volume);
    }

    public void StopSounds()
    {
        audioPlayer.Stop();
    }
}
