using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_Skitto_DialogAnimator : MonoBehaviour {

    public Animator SkittoDialogAnimator;

    public void PlayAwesome()
    {
        SkittoDialogAnimator.SetBool("Awesome", true);
    }
    public void HideAwesome()
    {
        SkittoDialogAnimator.SetBool("Awesome", false);
    }

    public void PlayGoodJob()
    {
        SkittoDialogAnimator.SetBool("GoodJob", true);
    }
    public void HideGoodJob()
    {
        SkittoDialogAnimator.SetBool("GoodJob", false);
    }
    public void PlayGetCoverd()
    {
        SkittoDialogAnimator.SetBool("GetCovered", true);

    }
    public void HideGetCovered()
    {
        SkittoDialogAnimator.SetBool("GetCovered", false);
    }
    public void SetEndAnimation()
    {
        SkittoDialogAnimator.SetTrigger("end");
    }

}
