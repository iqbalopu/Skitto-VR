using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level_3_GameController : MonoBehaviour {
    public static Level_3_GameController Instance;

#region Game Objects
    public GameObject go_Gameover_board;
    public GameObject go_counter;
    public GameObject go_times_up;
#endregion
#region Public Variables
    public int nt_countdownCount = 3;
    public bool isGameStarted   = false;
    public bool isGameOver      = false;

    public int ntGameTimeInSeconds;
    public ParticleSystem WallDestroyParticle;
    public GameObject Wall;
    public bool OnFreeze;// used by fruit spawanner
    public bool OnFire;
    #endregion

    // Use this for initialization

    public Animator tutorial, fireCombo, freezeCombo, light;

    private void Awake()
    {
        Instance = this;
        Physics.gravity = new Vector3(0, -3, 0);
    }

    private void OnLevelWasLoaded(int level)
    {
        
    }

    void Start ()
    {
        OnFreeze = false;
        OnFire   = false;

        // wwww giving big time, to win the game
        ntGameTimeInSeconds = 300;

        light.SetBool("isLightOn", true);
        //SetTimeTextInMinutesAndSeconds();
        //StartCoroutine("CountDown");
        Invoke("HideTutorial", 10);
    }

    public void HideTutorial()
    {
        tutorial.SetBool("disappear", true);
        Invoke("StartGame", 0.5f);
    }

    public void StartGame()
    {
        //tutorial.gameObject.SetActive(false);

        SetTimeTextInMinutesAndSeconds();
        StartCoroutine("CountDown");
    }
	
    public Component[] meshes;

    public void GameOver()
    {
        isGameOver = true;
        // Stop all kinds of spawning
        Level_3_FruitSpawner.Instance.StopSpawning();
        go_times_up.SetActive(true);
        Level_3_UIController.Instance.WallDissappear();
        Invoke("EnableGameOverBoard", 2.0f);
    }

    public void GameWin()
    {
        isGameOver = true;
        // Stop all kinds of spawning
        Level_3_FruitSpawner.Instance.StopSpawning();
        Level_3_UIController.Instance.WallDissappear();
        CancelInvoke("TimeCount");
        Level_3_AudioManager.instance.stopLightsaber();
        // Level_3_UIController.Instance.SetWinningInstruction();
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Invoke("EnableGameOverBoard", 2.0f);
        Invoke("DissableLight", 7.0f);
        //Invoke("MoveToNextScene", 4f);
    }

    public void DissableLight()
    {
        light.SetBool("isLightOn", false);
        Invoke("FadeCamera", 3f);
    }

    public void FadeCamera() {

        Level_3_UIController.Instance.SetCameraFade();
    }

    public void MoveToNextScene()
    {
        //Application.LoadLevel(4);
        LevelChangeController.instance.LoadNextLevel(4);
    }

    public void EnableGameOverBoard()
    {
        go_Gameover_board.SetActive(true);
        Level_3_ScoreManager.instance.SetGameOverScore();
        Invoke("Play_DestroyParticle_Invoke", 2f);
        Invoke("MoveToNextScene", 8f);
    }
    void Play_DestroyParticle_Invoke()
    {
        WallDestroyParticle.Play();
        Level_3_AudioManager.instance.Play_WallDestroyAudio();
        Invoke("SetWallInactive_Invoke", 0.1f);
    }
    void SetWallInactive_Invoke()
    {
        Wall.SetActive(false);
    }

    public void RemoveGameOver()
    {
        go_Gameover_board.SetActive(false);
    }

    IEnumerator CountDown()
    {
        // go_counter.GetComponent<Animator>().SetBool("appear", true);
        for (int i = 0; i < 3; i++)
        {
            Level_3_UIController.Instance.SetThreeTwoOne((3 - i));
            yield return new WaitForSeconds(1.5f);
        }

        Level_3_UIController.Instance.SetThreeTwoOne(0);
        go_counter.GetComponent<Animator>().SetBool("appear", false);

        Level_3_AudioManager.instance.PlayDong();

        // Level_3_AudioManager.instance.PlayGameAudio();
        isGameStarted = true;

        Level_3_FruitSpawner.Instance.StartSpawning();
        InvokeRepeating("TimeCount", 0, 1);
    }

    // wwww score 20, game is over
    public void TimeCount()
    {
        SetTimeTextInMinutesAndSeconds();
        if (ntGameTimeInSeconds <=0)
        {
            CancelInvoke("TimeCount");
            Level_3_FruitSpawner.Instance.EndSpawning();
            GameOver();
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }

    public void SetTimeTextInMinutesAndSeconds()
    {
        --ntGameTimeInSeconds;
        int nt_minutes = ntGameTimeInSeconds / 60;
        int nt_seconds = ntGameTimeInSeconds - (nt_minutes * 60);
        Level_3_UIController.Instance.SetTimeRemaining(nt_minutes, nt_seconds);

        if (ntGameTimeInSeconds <=0)
        {
            GameOver();
        }
    }
    
    public void onPause()
    {
        // Set timescale to 0
    }

    public void FreezeTimeScale() // called from fruit
    {
        freezeCombo.SetTrigger("appear");

        if (OnFire)
        {
            OnFire = false;
        }

        Time.timeScale = .5f;
        Invoke("ResetTimeScale", 5);
        OnFreeze = true;
        Level_3_FruitSpawner.Instance.StartFreezeSpawning();
    }

    public void ResetTimeScale()
    {
        Level_3_FruitSpawner.Instance.StopFreezeSpawning();
        OnFreeze = false;
        Time.timeScale = 1;
    }

    public void SetOnFire()// Called from Sword.OnCollisionEnter
    {
        fireCombo.SetTrigger("appear");

        if (OnFreeze)
        {
            OnFreeze = false;
        }
        OnFire = true;
        Invoke("StopOnFire", 10);
    }

    public void StopOnFire()
    {
        OnFire = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}