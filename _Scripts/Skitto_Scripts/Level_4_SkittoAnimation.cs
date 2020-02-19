using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SkittoAnimation : MonoBehaviour {

    #region _____Public variables_____
    [Header("_____Animator Variables_____")]
    public Animator skittoAnimator;
    public Animator FistBumpDialougeAnimator;
    [Header("_____GameObject Variables_____")]
    public GameObject mouthOff;
    public GameObject mouthOn;
    public GameObject mouthSmile;
    public GameObject eyeNormal;
    public GameObject eyeWink;
    [Header("_____Script Variables_____")]
    public Level_4_Skitto_DialogAnimator dialogAnimator;
    #endregion
    #region _____Private Variables_____
    Level_4_SkittoAudio skittoAudio;
    #endregion
    private void Awake()
    {
        skittoAudio = GetComponentInChildren<Level_4_SkittoAudio>();
        mouthOff.SetActive(true);
        mouthOn.SetActive(false);
        mouthSmile.SetActive(false);
        eyeNormal.SetActive(true);
        eyeWink.SetActive(false);
    }
    public void Play_Skitto_Fly()
    {
        skittoAnimator.SetBool("fly", true);
        mouthOff.SetActive(true);
        mouthOn.SetActive(false);
    }
    public void Play_Skitto_Idle()
    {
        skittoAnimator.SetBool("fly", false);
        mouthOff.SetActive(false);
        mouthOn.SetActive(true);
        eyeNormal.SetActive(true);
    }
    public void Play_Skitto_fistBumpWait()
    {
        skittoAnimator.SetBool("fistBump", true);

    }
    public void Play_skitto_fistBumpDone()
    {
        skittoAnimator.SetBool("fistBump", false);
        mouthSmile.SetActive(true);
        eyeWink.SetActive(true);
        mouthOn.SetActive(false);
        eyeNormal.SetActive(false);
        Invoke("Reset_MouthAndEye", 0.5f);
    }
    void Reset_MouthAndEye()
    {
        mouthSmile.SetActive(false);
        eyeWink.SetActive(false);
        mouthOn.SetActive(true);
        eyeNormal.SetActive(true);
    }
    public void Play_skitto_EatSnake()
    {
        skittoAnimator.SetBool("eat", true);
        skittoAudio.Play_EatingSnakeAudio();
    }
    public void Stop_skitto_EatSnake()
    {
        skittoAnimator.SetBool("eat", false);
        skittoAudio.Pause_SkittoAudio();
    }
    public void TriggerIdlePose()
    {
        skittoAnimator.SetTrigger("IdleTrigger");
        dialogAnimator.HideAwesome();
        dialogAnimator.HideGoodJob();
        dialogAnimator.HideGetCovered();
    }
    public void Play_SetCheer_Cover_Awesome()
    {
        Invoke("Play_SetCheer_Cover_Awesome_Invoke", 5f);
    }
    public void Play_SetCheer_Cover_Awesome_Invoke()
    {
        skittoAnimator.SetBool("Start", true);
        mouthOff.SetActive(false);
        mouthOn.SetActive(true);
        eyeNormal.SetActive(true);
    }
    public void Play_FistBumpDialougeAppear()
    {
        FistBumpDialougeAnimator.SetBool("Appear", true);
    }
    public void Play_FistBumpDialougeDisappear()
    {
        FistBumpDialougeAnimator.SetBool("Appear", false);
    }
}
