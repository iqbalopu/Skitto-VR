using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_EnvironmentEffectController : MonoBehaviour
{

    public static Level_3_EnvironmentEffectController Instance;
    [Header("Frie and Freeze Variables")]
    public ParticleSystem FireParticle, FreezeParticle;

    [Header("Frenzy Variables")]
    public Animator FrenzyRollerLeft_Animator;
    public ParticleSystem ConfettiFrenzyLeft;

    public Animator FrenzyRollerRight_Animator;
    public ParticleSystem ConfettiFrenzyRight;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ShowNoParticle();
    }

    void ShowNoParticle()
    {
        HideFreeze();
        HideFire();
    }


    #region Fire Methods
    public void ShowFire()
    {
        FireParticle.gameObject.SetActive(true);
        FireParticle.Play();
    }

    public void HideFire()
    {
        FireParticle.Stop();
        Invoke("HideFireInvoke", 2);
    }
    void HideFireInvoke()
    {
        FireParticle.gameObject.SetActive(false);
    }
    #endregion

    #region Freeze Methods
    public void ShowFreeze()
    {
        FreezeParticle.gameObject.SetActive(true);
        FreezeParticle.Play();
    }
    public void HideFreeze()
    {
        FreezeParticle.Stop();
        Invoke("HideFreezeInvoke", 2);
    }
    void HideFreezeInvoke()
    {
        FreezeParticle.gameObject.SetActive(false);
    }

    #endregion


    #region Frenzy Methods
    //*********** LEFT SIDE ******************//
    public void StartFrenzyLeft()
    {
        FrenzyRollerLeft_Animator.SetBool("Rotate", true);
        ConfettiFrenzyLeft.gameObject.SetActive(true);
        ConfettiFrenzyLeft.Play();
    }
    public void StopFrenzyLeft()
    {
        FrenzyRollerLeft_Animator.SetBool("Rotate", false);
        ConfettiFrenzyLeft.Stop();
        Invoke("HideFrenzyConfettiLeft", 2);
    }
    void HideFrenzyConfettiLeft()
    {
        ConfettiFrenzyLeft.gameObject.SetActive(false);
    }

    // ************* RIGHT SIDE ***************//
    public void StartFrenzyRight()
    {
        FrenzyRollerRight_Animator.SetBool("Rotate", true);
        ConfettiFrenzyRight.gameObject.SetActive(true);
        ConfettiFrenzyRight.Play();
    }
    public void StopFrenzyRight()
    {
        FrenzyRollerRight_Animator.SetBool("Rotate", false);
        ConfettiFrenzyRight.Stop();
        Invoke("HideFrenzyConfettiRight", 2);
    }
    void HideFrenzyConfettiRight()
    {
        ConfettiFrenzyRight.gameObject.SetActive(false);
    }
    #endregion


}
