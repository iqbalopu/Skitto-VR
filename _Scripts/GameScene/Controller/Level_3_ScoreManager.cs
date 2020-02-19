using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_3_ScoreManager : MonoBehaviour {

    private const string HighestScore   = "HighestScore";

    private const string totalScore = "TotalScore";

    private const string totalPlayed = "TotalPlayed";

    public static Level_3_ScoreManager instance;

    public int TargetScore = 20;

    public int userScore;

    public bool OnSpecialFruitScore;

    public bool clearPrefabs;

    // Use this for initialization
    void Start()
    {
        OnSpecialFruitScore = false;
        instance = this;

        userScore = 0;

       // UI_Controller.instance.SetHighScoreText("Score : " + userScore.ToString());

        if (!PlayerPrefs.HasKey(HighestScore))
        {
            PlayerPrefs.SetInt(HighestScore, 0);
        }

        Level_3_UIController.Instance.SetTargetScore(userScore+"/"+TargetScore);
        Level_3_UIController.Instance.SetScore(userScore);

        if (clearPrefabs)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    // wwww count fruits here, total 20
    public void AddScore()
    {
         Level_3_ComboCalculator.Instance.CalculteCombo();

        //if (OnSpecialFruitScore)
        //{
        //    userScore += 30;
        //}
        //else
        //    userScore += 10;

        if (userScore >= TargetScore)
        {
            return;
        }

        userScore += 1;
        if (userScore >= TargetScore)
        {
            Level_3_GameController.Instance.GameWin();
            //userScore = TargetScore;
        }

        // Level_3_UI_Controller.instance.SetHighScoreText("Score : " + userScore.ToString());
        Level_3_UIController.Instance.SetScore(userScore);
        Level_3_UIController.Instance.SetTargetScore(userScore+"/"+TargetScore);
    }

    public void AddSpecialFruitScore()
    {
        userScore += 10;
        OnSpecialFruitScore = true;
        Invoke("StopSpecialScore", 10);
    }

    void StopSpecialScore()
    {
        OnSpecialFruitScore = false;
    }

    public void ReduceScore(int nt_reduction)
    {
        if (userScore > nt_reduction)
        {
            userScore -= nt_reduction;
        }
        else
        {
            userScore = 0;
        }

        Level_3_UIController.Instance.SetScore(userScore);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        // anim.SetBool("Dying", true);
    //        // 
    //        // obj
    //        //Debug.LogError("Showing up csv data"); 
    //        showInExcelMonthlyData();
    //    }

    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        // anim.SetBool("Dying", true);
    //        // 
    //        // obj
    //        //Debug.LogError("Showing up csv data"); 
    //        PlayerPrefs.SetInt(totalPlayed, PlayerPrefs.GetInt(totalPlayed) + 1);
    //    }
    //}
    

    public bool SetHighestScore(int score)
    {
        PlayerPrefs.SetInt(totalPlayed, PlayerPrefs.GetInt(totalPlayed) + 1);
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt(totalScore, PlayerPrefs.GetInt(totalScore) + score);

        if (score > PlayerPrefs.GetInt(HighestScore))
        {
            PlayerPrefs.SetInt(HighestScore, score);

            Level_3_UIController.Instance.SetTargetScore(userScore+"/"+TargetScore);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetGameOverScore()
    {
        SetHighestScore(userScore);
        Level_3_UIController.Instance.SetGameoverScore(userScore);
        Level_3_UIController.Instance.SetGameoverHighScore(PlayerPrefs.GetInt(HighestScore));
    }
}