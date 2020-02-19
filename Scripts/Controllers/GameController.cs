using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    
    public static GameController instance;
    public bool RaceStart;
    public bool isDead;
    public bool GameOver;


    public delegate void RaceStartAction();
    public RaceStartAction OnRaceStart;
    
    public RaceStartAction OnCountDownStart;

    public GameObject InstructionObject;
    private void Awake()
    {
        QualitySettings.antiAliasing = 8;
        instance = this;
    }
    private void Start()
    {
        RaceStart = false;
        isDead = false;
        GameOver = false;
        if (!PlayerPrefs.HasKey("GameDurationMili"))
        {
            PlayerPrefs.SetFloat("GameDurationMili",9999999);
        }
        UI_Controller.instance.SetBestScore((int)PlayerPrefs.GetFloat("GameDurationMili"));
    }
    public void Set_RaceStart()
    {
        if (!RaceStart)
        {
            DragonController.instance.SetStartFollowing();
            OnRaceStart();
            RaceStart = true;
            InstructionObject.SetActive(false);
        }
        
		//AudioController.instance.PlayRaceMusic ();
    }
    public void Set_CountDownStart()
    {
        OnCountDownStart();
    }
    public void SetDead()
    {
        isDead = true;
    }
    public void SetGameOver()
    {
        DragonController.instance.StopFollowing();
        GameOver = true;
        //UI_Controller.instance.SetPosition(BIKE_AI_Position.instance.CheckPostion());
        UI_Controller.instance.SetTime(GameTimeController.instance.GameTimeUpdateInvoker());
        if (GameTimeController.instance.GameDurationMili < PlayerPrefs.GetFloat("GameDurationMili"))
        {
            PlayerPrefs.SetFloat("GameDurationMili", (int)GameTimeController.instance.GameDurationMili);
            UI_Controller.instance.SetGameOverText("Cool!!\n Time To Cut Some Fruits!");
            UI_Controller.instance.SetBestScore((int)GameTimeController.instance.GameDurationMili);
        }
        else
        {
            UI_Controller.instance.SetGameOverText("Cool!!\n Time To Cut Some Fruits!");
        }
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        LoadMenuLevel();
    //    }
    //}
    //public void LoadGameLevel()
    //{
    //    SceneManager.LoadScene(1);
    //}
    //public void LoadMenuLevel()
    //{
    //    SceneManager.LoadScene(0);
    //}
}
