using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_3_UIController : MonoBehaviour {

    public Animator TutorialAnimator;
    public static Level_3_UIController Instance;
    public Animator amt_camera_fade;

    #region Text Access
    public TextMeshPro txt_score;
    public TextMeshPro txt_high_score;

    public TextMeshPro txt_gameover_score;
    public TextMeshPro txt_gameover_high_score;

    public TextMeshPro txt_time_remaining;
    public TextMeshPro txt_combo;
    public TextMeshPro txt_three_two_one;


    public GameObject MulaEffect, KathalEffect, KolaEffect, BangiEffect;

    public TextMeshAnimate_Console instructionTMPro;
//    OFFER[ER MULA]
//SORTER BANGI
//SMS[ER KACHKOLA]
//COST[ER KATHAL]

    

    #endregion
    
    private void Awake()
    {
        Instance = this;
    }

    public void SetThreeTwoOne(int nt_count)
    {
        if (nt_count == 0)
        {
            txt_three_two_one.text = "GO";
        }
        else
        {
            txt_three_two_one.text = nt_count.ToString();
        }
    }

    public void SetScore(int nt_score)
    {
        txt_score.text = "SCORE: " + nt_score.ToString();
    }

    public void SetTargetScore(string st_Score)
    {
        txt_high_score.text = "Fruits\n" + st_Score;
    }

    public void SetGameoverScore(int nt_score)
    {
        txt_gameover_score.text = "SCORE: " + nt_score.ToString();
    }

    public void SetGameoverHighScore(int nt_score)
    {
        txt_gameover_high_score.text = "BEST: " + nt_score.ToString();
    }

    public void SetTimeRemaining(int min, int sec)
    {
        txt_time_remaining.text = min.ToString() + ":" + sec.ToString();
    }

    // wwww sorter mula, 
    public void SetCombo(int nt_combo)
    {
        //Good = 3, Excellent = 3, Awesome > 5
        //if ((nt_combo + 1) >= 5) 
        //{
        //    Combo5X.SetTrigger("appear");
        //    txt_combo.text = "AWESOME!! \n X" + (nt_combo + 1).ToString();
        //}
        //else if ((nt_combo + 1) >= 3)
        //{
        //    Combo3X.SetTrigger("appear");
        //    txt_combo.text = "EXCELLENT!! \n X" + (nt_combo + 1).ToString();
        //}
        //else if ((nt_combo + 1) >= 2)
        //{
        //    txt_combo.text = "GOOD!! \n X" + (nt_combo + 1).ToString();
        //}
    }
    // SetSorterMula
    public void SetOfferErMula(Vector3 position)
    {
        position.z = 3.75f; 
        Instantiate(MulaEffect, position, Quaternion.identity);
    }

    public void SetSorterBangi(Vector3 position)
    {
        position.z = 3.75f;
        Instantiate(BangiEffect, position, Quaternion.identity);
    }

    public void SetSMSerKachKola(Vector3 position)
    {
        position.z = 3.75f;
        Instantiate(KolaEffect, position, Quaternion.identity);
    }

    public void SetCostErKathal(Vector3 position)
    {
        position.z = 3.75f;
        Instantiate(KathalEffect, position, Quaternion.identity);
    }

//OFFER[ER MULA]
//SORTER BANGI
//SMS[ER KACHKOLA]
//COST[ER KATHAL]
    public Animator WallAnimator;

    public void WallDissappear()
    {
        WallAnimator.SetTrigger("disappear");
    }

    public void SetCuttingInstruction()
    {
        if(instructionTMPro.isActiveAndEnabled)
        instructionTMPro.SetText("Cut them down!!");
    }

    public void SetWinningInstruction()
    {
        TutorialAnimator.SetBool("disappear", false);
        if (instructionTMPro.isActiveAndEnabled)
            instructionTMPro.SetText("Awesome!! \n You are a True Ninja!!");
    }

    public void SetCameraFade()
    {
        amt_camera_fade.SetBool("fade", true);
    }
}