using UnityEngine;
using System.Collections;

public class Level_3_AudioManager : MonoBehaviour {

    public AudioSource SpecialSFX;
    public static Level_3_AudioManager instance;
         
    public AudioClip Menu_Audio, Game_Audio;

    public AudioSource BG_AudioSource, SFX_AudioSource, BombSFX, DongSFX, FrenzySFXClock,WallDestroySource;
    public AudioSource LightSaberLeft, LightSaberRight,LightSaberStart;
    public AudioSource[] canonBloop;

    public AudioClip slash1, slash2, slash3, boom, buttonClick, waveClip;

    public AudioClip Fire, Freeze, Double;

    public AudioClip[] chopAudioClips;

    public AudioClip[] Special2X;
    int Special2XIndex;

    void Start()
    {
        Special2XIndex = 0;
        instance = this;
        PlayMenuAudio();

        isLeftSwordOpen = false;
        isRightSwordOpen = false;
        // InvokeRepeating("PlayDong", 2, 3);
        // Invoke("lightsaberStart", 3);
        // Invoke("lightsaberPlayWave", 5);
    }

    public bool isLeftSwordOpen, isRightSwordOpen;
    public void PlayLightSaberStart(bool isLeft) {

        Debug.Log("PlayLightSaberStart calling!");
        if (isLeft && !isLeftSwordOpen)
        {
            LightSaberStart.Play();
            isLeftSwordOpen = true;
            Debug.Log("Lightsaber effect playing");
        }
        else if (!isLeft && !isRightSwordOpen)
        {
            LightSaberStart.Play();
            isRightSwordOpen = true;
            Debug.Log("Lightsaber effect playing");
        }
        if (isLeftSwordOpen && isRightSwordOpen)
        {
            Level_3_UIController.Instance.SetCuttingInstruction();
        }
    }

    public void lightsaberPlayWave(float volume) {

        LightSaberStart.Play();
    }

    public void Set_LightSaberRight(float volume)
    {
        if (isRightSwordOpen)
        {
            LightSaberRight.volume = Mathf.Lerp(LightSaberRight.volume, volume / 5, Time.deltaTime * 50);
        }
        else
        {
            LightSaberRight.volume = 0;
        }
        
    }
    public void Set_LigthSaberLeft(float volume)
    {
        if (isLeftSwordOpen)
        {
            LightSaberLeft.volume = Mathf.Lerp(LightSaberRight.volume, volume / 5, Time.deltaTime * 50);
        }
        else
        {
            LightSaberLeft.volume = 0;
        }
        
    }

    public void PlayBloop()
    {
        // Debug.LogError("Bloop calling!!");
        // canonBloop.Stop();
        canonBloop[Random.Range(0, canonBloop.Length - 1)].Play();
    }

    public void stopLightsaber() {
        //LightsaberWave.Stop();
    }

    public void PlayDong()
    {
        DongSFX.Stop();
        DongSFX.Play();
        Debug.LogError("Playing Dong!!"); 
    }

    public void PlayTikTik()
    {
        FrenzySFXClock.Stop();
        // FrenzySFXClock.clip = Menu_Audio;
        FrenzySFXClock.Play();
        FrenzySFXClock.loop = true;
    }

    public void StopTikTik()
    {
        FrenzySFXClock.Stop();
    }

    public void PlayMenuAudio()
    {
        BG_AudioSource.Stop();
        BG_AudioSource.clip = Menu_Audio;
        BG_AudioSource.Play();
        BG_AudioSource.loop = true;
    }

    public void PlayGameAudio()
    {
        BG_AudioSource.Stop();
        BG_AudioSource.clip = Game_Audio;
        BG_AudioSource.Play();
        BG_AudioSource.loop = true;
    }
    
    public void playSlash1()
    {
        playSFX(slash1);
    }
    public void playSlash2()
    {
        playSFX(slash2);
    }
    public void playSlash3()
    {
        playSFX(slash3);
    }

    public void playBoom()
    {
        PlayBombSFX(boom);
    }

    public void playChops()
    {
        AudioClip clip = chopAudioClips[Random.Range(0, chopAudioClips.Length)];
        playSFX(clip);
    }
    public void PlayFire()
    {
        PlaySpecialSFX(Fire);
    }
    public void PlayFreeze()
    {
        PlaySpecialSFX(Freeze);
        PlayFreezeEffect();
    }
    void PlayFreezeEffect()
    {
        BG_AudioSource.GetComponent<Animator>().SetTrigger("FreezeEffect");
    }
    public void Play2X()
    {
        AudioClip clip = Special2X[Special2XIndex];
        Special2XIndex = (Special2XIndex + 1) % Special2X.Length;
        PlaySpecialSFX(clip);
    }
    public void playButtonClick()
    {
        
        playSFX(buttonClick);
    }
    
    void playSFX(AudioClip sfxClip)
    {
        SFX_AudioSource.Stop();
        SFX_AudioSource.clip = sfxClip;
        SFX_AudioSource.Play();
        SFX_AudioSource.loop = false;
    }
    void PlayBombSFX(AudioClip sfxClip)
    {
        BombSFX.Stop();
        BombSFX.clip = sfxClip;
        BombSFX.Play();
        BombSFX.loop = false;
    }
    void PlaySpecialSFX(AudioClip sfxClip)
    {
        SpecialSFX.Stop();
        SpecialSFX.clip = sfxClip;
        SpecialSFX.Play();
        SpecialSFX.loop = false;
    }

    public void PauseAudio()
    {
        BG_AudioSource.Pause();
        //SFX_AudioSource.Pause();
    }

    public void ResumeAudio()
    {
        BG_AudioSource.UnPause();
        //SFX_AudioSource.UnPause();
    }
    public void Play_WallDestroyAudio()
    {
        WallDestroySource.Play();
    }
}
