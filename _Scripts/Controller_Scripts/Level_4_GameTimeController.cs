using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_GameTimeController : MonoBehaviour {
#region __________Public Variables_________
    public static Level_4_GameTimeController instance;
    [Header("_____Animator Variables_____")]
    public Animator GameOverPanel,GameWinPanel,CountDownPanelAnim;
    public Animator SpriteAnimation;
    [Header("_____Boolean Variables_____")]
    public bool gameTimeOn,gameOver,eatSnake,fistBump,MoveToStart;
    public bool getFistBump;
    public bool jilapiDead;
    [Header("____Particle Variables____")]
    public ParticleSystem fire1, fire2, fire3,fire4;
    #endregion
#region ________Private Methods_________
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gameTimeOn = false;
        gameOver = false;
        eatSnake = false;
        fistBump = false;
        getFistBump = false;
        MoveToStart = false;
        jilapiDead = false;

        Invoke("AppearSpriteAnimation", 3f);
        Level_4_AudioController.instance.PlayBGAudio();
    }
    void AppearSpriteAnimation()
    {
        SpriteAnimation.SetBool("Appear", true);
        Invoke("StartCountDown", 3f);
    }

    void StartCountDown()
    {
        CountDownPanelAnim.SetBool("Appear", true);
        Level_4_AudioController.instance.Play_CountDownAudio();
        Invoke("StartGamePlay", 4f);
    }
    void StartGamePlay()
    {
        gameTimeOn = true;
        
    }
    void MoveToStart_Invoke()
    {
        MoveToStart = true;
    }
#endregion
    #region ________Public Methods________
    public void ShowGameOverPanel_PlayerDead()
    {
        GameOverPanel.SetBool("Appear", true);
    }
    public void ShowGameOverPanel_SnakeDead()
    {
        GameWinPanel.SetBool("Appear", true);
    }
    public void OnGameOver()
    {
        ShowGameOverPanel_SnakeDead();
        Invoke("MoveToStart_Invoke", 2f);
        fire1.Play();
        fire2.Play();
        fire3.Play();
        fire4.Play();
    }
#endregion
}
