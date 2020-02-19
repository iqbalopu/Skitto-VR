using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bike_Effect : MonoBehaviour {

    public TextMeshPro speedoMeter;
    public TextMeshPro nitroText;
    public ParticleSystem NitroParticle;
    public ParticleSystem LandingParticle;
    public ParticleSystem LeftSpark, RightSpark;
    public void SetNitro(bool state)
    {
        if (state)
        {
            if (!NitroParticle.isPlaying)
            {
                NitroParticle.Play();
            }
            
        }
        else
        {
            if (NitroParticle.isPlaying)
            {
                NitroParticle.Stop();
            }
            
        }
    }
    public void SetSpeedoMeter(float speed)
    {
        speedoMeter.text = "" + (int)speed * 3;
    }
    public int CurrentNitro = 0;
    public void SetNitro(float nitroValue)
    {
        CurrentNitro = (int)(nitroValue * 5);
        if (CurrentNitro != nitroText.text.Length)
        {
            nitroText.text = "";
            for (int i = 0; i < CurrentNitro; i++)
            {
                nitroText.text += "<";
            }
        }
    }
    public void PlaySpark(int type) //0 = all, -1=left, 1= right
    {
        if (type == 0)
        {
            LeftSpark.Play();
            RightSpark.Play();
            Invoke("StopRightSpark", 2);
            Invoke("StopLeftSpark", 2);
        }
        else if (type == -1)
        {
            LeftSpark.Play();
            Invoke("StopLeftSpark", 2);
        }
        else if (type == 1)
        {
            RightSpark.Play();
            Invoke("StopRightSpark", 2);
        }
    }
    public void StopRightSpark()
    {
        RightSpark.Stop();
    }
    public void StopLeftSpark()
    {
        LeftSpark.Stop();
    }

    public void PlayLandingParticle()
    {
        LandingParticle.Play();
    }
	
}
