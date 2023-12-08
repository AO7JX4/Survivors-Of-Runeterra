using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip musicOnStart;
    [SerializeField] float timeToSwitch;

    public AudioSource audioSource;
    AudioClip switchTo;
    float volume;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Play(musicOnStart, true);
    }

    public void Play(AudioClip music, bool interrupt = false)
    {
        if(interrupt == true)
        {
            volume = 1f;
            audioSource.volume = volume;
            audioSource.clip = music;
            audioSource.Play();
        }
        else
        {
            switchTo = music;
            StartCoroutine(SmoothMusicSwitch());
        }
    }

    IEnumerator SmoothMusicSwitch()
    {
        volume = 1f;

        while(volume > 0f)
        {
            volume -= Time.deltaTime / timeToSwitch;
            if(volume < 0f)
            {
                volume = 0f;
            }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }

        Play(switchTo, true);
    }
}
