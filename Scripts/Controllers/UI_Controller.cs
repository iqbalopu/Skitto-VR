using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_Controller : MonoBehaviour {

    public TextMeshPro GameOverText;
    //public TextMeshPro PositionText;
    //public TextMeshPro timeText;
    public TextMeshPro timeTextDashboard;
    public static UI_Controller instance;
    public TextMeshPro bestScrore;

    public ParticleSystem[] startingParticle;

    private void Awake()
    {
        instance = this;
    }
    public void SetPosition(int position)
    {
        string suffix = "";
        if (position == 1)
        {
            suffix = "st";
        }
        else if (position == 2)
        {
            suffix = "nd";
        }
        else if (position == 3)
        {
            suffix = "rd";
        }
        else
        {
            suffix = "th";
        }
        //PositionText.text = "<size=50>" + position + "</size>"+suffix;
    }
    public void SetTime(string time)
    {
        //timeText.text = "Time: "+time;
    }
    public void SetTimeTextDashboard(string time)
    {
        timeTextDashboard.text = time;
    }
    public void SetBestScore(int gameDuration)
    {
        bestScrore.text = "BEST" + System.Environment.NewLine +GameTimeController.instance.ConvertMili_To_String(gameDuration);
                            
    }
    public void SetGameOverText(string BestTime)
    {
        GameOverText.text = BestTime;
    }

    public void PlayStartingParticleEffect()
    {
        foreach (ParticleSystem p in startingParticle)
        {
            p.Play();
        }
    }
}
