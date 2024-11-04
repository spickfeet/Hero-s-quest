using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("-------Audio Clips-------")]
    public AudioClip Music;
    public AudioClip SFX;
    public AudioClip Scroll;

    private void Start()
    {
        _musicSource.clip = Music;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip, float volume = 1)
    {
        if (audioClip == null) return;

        _sfxSource.PlayOneShot(audioClip, volume);
    }
}
