using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SkittoAudio : MonoBehaviour {

    AudioSource skittoAS;
    public AudioClip clp_eatingSnake,clp_FistBump;
    private void Awake()
    {
        skittoAS = GetComponentInChildren<AudioSource>();
    }
    public void Play_EatingSnakeAudio()
    {
        skittoAS.Stop();
        skittoAS.loop = true;
        skittoAS.clip = clp_eatingSnake;
        skittoAS.Play();
    }
    public void Pause_SkittoAudio()
    {
        skittoAS.Pause();
    }
    public void Play_FistBumpAudio()
    {
        skittoAS.Stop();
        skittoAS.loop = false;
        skittoAS.clip = clp_FistBump;
        skittoAS.Play();
    }
}
