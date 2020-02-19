using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableSwitch : MonoBehaviour {

    public SwtichAbstract CallBackClass;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftController") || other.CompareTag("RightController"))
        {
            CallBackClass.OnSwitchPressed();
            Level_1_1_Audio.instance.PlaySwitchSound();
        }
    }
}
