using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeAudio : MonoBehaviour {

    public AudioSource snakeAudio,SnakeHITAudio,ExplosiveThrowSource,SnakeDeath,HitGround;
    public AudioClip[] snakeHitAudioHolder;
    public AudioClip clp_ThrowExplosive, clp_DeathSound,clp_IdleSound,clp_JilapiHitGround;
    private void Start()
    {
        
    }
    public void PlayExplosiveThrowAudio()
    {
        ExplosiveThrowSource.Play();
    }
    public void PlaySnakeHurtSound()
    {
        int Index = Random.Range(0,snakeHitAudioHolder.Length);
        SnakeHITAudio.clip = snakeHitAudioHolder[Index];
        SnakeHITAudio.Play();   
    }
    public void PlaySnakeDeathSound()
    {
        //snakeAudio.Stop();
        //snakeAudio.loop = false;
        //snakeAudio.pitch = 0.5f;
        //snakeAudio.clip = clp_DeathSound;
        //snakeAudio.Play();
        SnakeDeath.Play();
        Level_4_AudioController.instance.PlayEndAudio();
        
    }
    public void Play_SnakeIdleAudio()
    {
        snakeAudio.Stop();
        snakeAudio.loop = true;
        snakeAudio.pitch = 0.5f;
        snakeAudio.clip = clp_IdleSound;
        snakeAudio.Play();
    }
    public void Stop_SnakeAudio()
    {
        snakeAudio.Stop();
    }
    public void PlayJilapiHitGroundAudio()
    {
        //snakeAudio.Stop();
        //snakeAudio.loop = false;
        //snakeAudio.pitch = 0.5f;
        //snakeAudio.clip = clp_JilapiHitGround;
        //snakeAudio.Play();
        HitGround.Play();
    }
}
