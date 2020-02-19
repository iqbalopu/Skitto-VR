using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_1_Audio : MonoBehaviour {
    public static Level_1_1_Audio instance;

    public AudioSource IndoorAmb, OutdoorAmb, SwitchSound, Lift,DoorSound,DisplayConsoleMoveSound,RocketDoorOpenSound;
    private void Awake()
    {
        instance = this;
    }
    public void PlayIndoorAmbience()
    {
        IndoorAmb.PlayOneShot(IndoorAmb.clip);
        IndoorAmb.loop = true;
    }
    public void StopIndoorAmbience()
    {
        IndoorAmb.Stop();
    }
    public void PlayOutdoorAmb()
    {
        OutdoorAmb.Play();
        OutdoorAmb.loop = true;
    }
    
    public void PlayLiftUpSound()
    {
        Lift.PlayOneShot(Lift.clip);
        Lift.loop = true;
    }
    public void StopLiftUp()
    {
        Lift.Stop();
    }
    public void PlaySwitchSound()
    {
        SwitchSound.PlayOneShot(SwitchSound.clip);
        SwitchSound.loop = false;
    }

    public void PlayDoorSound()
    {
        DoorSound.PlayOneShot(DoorSound.clip);
        DoorSound.loop = false;
    }
    public void PlayDisplayConsoleMove()
    {
        DisplayConsoleMoveSound.PlayOneShot(DisplayConsoleMoveSound.clip);
        DisplayConsoleMoveSound.loop = false;
        GetComponent<Level_1_1_LiftController>().PlayGetDown();
    }
    public void RocketDoorOpen()
    {
        RocketDoorOpenSound.PlayOneShot(RocketDoorOpenSound.clip);
        RocketDoorOpenSound.loop = false;
    }
}
