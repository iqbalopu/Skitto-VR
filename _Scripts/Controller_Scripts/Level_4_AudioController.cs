using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_AudioController : MonoBehaviour {
    public static Level_4_AudioController instance;
    public AudioSource bgAudio,endAudio,countDownAudio,BatDestroySource,PoofAudioSource,CoilingAudioSource;
    

    private void Awake()
    {
        instance = this;
    }
    public void PlayBGAudio()
    {
        bgAudio.loop = true;
        bgAudio.Play();
    }
    public void StopBG()
    {
        bgAudio.Stop();
    }
    public void PauseBG()
    {
        bgAudio.Pause();
    }
    public void PlayEndAudio()
    {
        //endAudio.Stop();
        //endAudio.loop = true;
        endAudio.Play();
        //Debug.LogError("____________________Playing End Audio___________________");
    }
    public void StopEndAudio()
    {
        endAudio.Stop();
    }
    public void Play_CountDownAudio()
    {
        countDownAudio.Stop();
        countDownAudio.loop = false;
        countDownAudio.Play();
    }
    public void Play_BatDestroyAudio()
    {
        BatDestroySource.Play();
    }
    public void PlayPoof()
    {
        PoofAudioSource.Play();
    }
    public void PlayCoiling()
    {
        CoilingAudioSource.Play();
    }

}
