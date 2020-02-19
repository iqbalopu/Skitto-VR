using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_BatAudio : MonoBehaviour {

    AudioSource batAudioSource;
    public AudioClip[] batAudio;
    private void Awake()
    {
        batAudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        //InvokeRepeating("PlayBatSound_Invoker", 1.5f, 3f);
    }
    void PlayBatSound_Invoker()
    {
        int Index = Random.Range(0, batAudio.Length);
        batAudioSource.clip = batAudio[Index];
        batAudioSource.Play();
    }
    public void PlayBatDeadSound()
    {
        int Index = Random.Range(0, batAudio.Length);
        batAudioSource.clip = batAudio[Index];
        batAudioSource.Play();
    }
}
