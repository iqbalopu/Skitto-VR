using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class BikeAudioController : MonoBehaviour {


    public BikeMovement bikeMovement;
    
    private void Awake()
    {
        bikeMovement = GetComponent<BikeMovement>();
    }
    private void Start()
    {
        PlayJumpStart();
        Invoke("PlayJumpLanding", 5);
    }
    public AudioSource BikeEngine,SideCollide1,SideCollide2,Brake,Nitro,GroundCollision,HaltBrake, NitroRefill,JumpStart, JumpLanding;
    
    private void Update()
    {
        if (GameController.instance.RaceStart)
        {
            BikeEngine.pitch = 1 + bikeMovement.getSpeedRatio() * 2;
            if (bikeMovement.handlebar.NitroPressed)
            {
                if (!Nitro.isPlaying)
                {
                    Nitro.PlayOneShot(Nitro.clip);
                    Nitro.loop = false;
                }
            }
            else
            {
                Nitro.Stop();
            }
            Nitro.volume = bikeMovement.NitroValue;
        }
        else
        {
            BikeEngine.pitch = bikeMovement.handlebar.Vertical;
        }
        

    }
    public void BrakePressed()
    {
        if (!Brake.isPlaying)
        {
            Brake.PlayOneShot(Brake.clip);
            Brake.loop = false;
        }
    }
    public void PlayHaltBrake()
    {
        if (!HaltBrake.isPlaying)
        {
            HaltBrake.PlayOneShot(HaltBrake.clip);
            HaltBrake.loop = false;
        }
    }
    public void PlayGroundCollision()
    {
        GroundCollision.PlayOneShot(GroundCollision.clip);
        GroundCollision.loop = false;
    }
    public void PlaySideCollision()
    {
        if (Random.Range(0, 100) > 50)
        {
            SideCollide1.PlayOneShot(SideCollide1.clip);
            SideCollide1.loop = false;
        }
        else
        {
            SideCollide2.PlayOneShot(SideCollide2.clip);
            SideCollide2.loop = false;
        }
    }
    public void PlayNitroRefill()
    {
        if (!NitroRefill.isPlaying)
        {
            
            NitroRefill.PlayOneShot(NitroRefill.clip);
            NitroRefill.loop = false;
        }
    }
    public void PlayJumpStart()
    {
        JumpStart.Play();
        
        
    }
    public void PlayJumpLanding()
    {
        JumpLanding.Play();
        bikeMovement.bikeEffect.PlayLandingParticle();
    }


}
