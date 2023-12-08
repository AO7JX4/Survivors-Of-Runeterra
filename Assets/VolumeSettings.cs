using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public MusicManager musicManager;
    public Slider volumeSlider;

    private bool muted = false;
    private bool stopped = false;
    private float musicVolume;

    public void VolumeChanged()
    {
        musicVolume = volumeSlider.value;
        UpdateMusicVolume();
    }

    public void MusicVol()
    {
        if (muted)
        {
            UnmuteMusic();
        }
        else
        {
            MuteMusic();
        }
    }

    public void MusicPause()
    {
        if (stopped)
        {
            UnpauseMusic();
        }
        else
        {
            PauseMusic();
        }
    }

    private void UpdateMusicVolume()
    {
        musicManager.audioSource.volume = volumeSlider.value;
    }

    private void MuteMusic()
    {
        musicVolume = musicManager.audioSource.volume;
        musicManager.audioSource.volume = 0;
        muted = true;
    }

    private void UnmuteMusic()
    {
        musicManager.audioSource.volume = musicVolume;
        muted = false;
    }

    private void PauseMusic()
    {
        musicManager.audioSource.Pause();
        stopped = true;
    }

    private void UnpauseMusic()
    {
        musicManager.audioSource.UnPause();
        stopped = false;
    }
}

