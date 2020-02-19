using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Level_1_1_LiftController : SwtichAbstract{

    public TextMeshAnimate_Console textAnimator;
    public Animator animator_Cinematic_1_1;
    //public TM
    private void Start()
    {
        animator_Cinematic_1_1 = GetComponent<Animator>();
    }
    public override void OnSwitchPressed()
    {
        Debug.Log("Calling lift up");
        textAnimator.SetText("Going Up");
        animator_Cinematic_1_1.SetBool("LiftUp",true);
    }
    public void PlayGetDown()
    {
        textAnimator.SetText("Get Down");
    }
    
}
