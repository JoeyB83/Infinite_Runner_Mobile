using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] music;
    public AudioSource[] sfx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int trackNumber)
    {
        StopMusic();

        if (trackNumber < music.Length)
        {
            music[trackNumber].Play();
        }
    }

    public void StopMusic()
    {
        foreach (AudioSource track in music)
        {
            track.Stop();
        }
    }

    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < music.Length)
        {
            sfx[soundToPlay].Stop();
            sfx[soundToPlay].Play();
        }
    }

    public void PlaySFXPitched(int soundToPlay)
    {
        sfx[soundToPlay].pitch = Random.Range(0.8f, 1.2f);
        PlaySFX(soundToPlay);
    }
}
