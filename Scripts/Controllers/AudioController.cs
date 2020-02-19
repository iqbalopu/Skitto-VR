using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour {
    public static AudioController instance;
    public AudioSource CountdownAudio,RaceMusic,AccidentSound;
    public AudioMixer raceMusicMixer;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SlowMoRaceMusic();
    }
    public void PlayCountDownAudio()
    {
        CountdownAudio.Play();
        CountdownAudio.volume = 1;
        Debug.Log("Playing CountDown Audio");
    }
	public void PlayRaceMusic()
	{
		RaceMusic.Play ();
		RaceMusic.loop = true;
	}
    public void PlayAccidentSound()
    {
        AccidentSound.Play();
    }
    public void SlowMoRaceMusic()// called from GameTimeController.Slowmo
    {
        //RaceMusic.pitch = .3f;
        //RaceMusic.volume = .2f;
        raceMusicMixer.SetFloat("CuttOff", 5595.00f);
    }
    public void FixRaceMusic()
    {
        raceMusicMixer.SetFloat("CuttOff", 10595.00f);
        //RaceMusic.pitch = 1f;
        //RaceMusic.volume = 1f;
    }

    
    
}
