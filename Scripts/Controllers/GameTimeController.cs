using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameTimeController : MonoBehaviour {

    
    public TextMeshPro countDownText;
    public static GameTimeController instance;
    public int GameDurationMili=0;
    bool countDownComplete = false;

 

    private void Awake()
    {
        instance = this;
        countDownComplete = false;
    }
    public int countDownValue = 8;//12
    // Use this for initialization
    void Start () {
        //CountDownAnimator.SetTrigger("StartCountDown");
        InvokeRepeating("CountdownInvoke",0,.9f);
        //AudioController.instance.PlayCountDownAudio();
        AudioController.instance.PlayRaceMusic();
        //"Hey There\n Welcome to Planet\n <size=3><font=\"BARIOL_BOLD SDF\"><color=#B13DB5>skitto</color></font></size>"
        countDownText.SetText("Hey There\n Welcome to Planet\n <size=30><font=\"BARIOL_BOLD SDF\"><color=#B13DB5>skitto</color></font></size>");
    }
    void CountdownInvoke()
    {

        if (countDownValue == -2)
        {
            CancelInvoke("CountdownInvoke");
        }
        else if (countDownValue == 12)
        {
            countDownText.alignment = TextAlignmentOptions.Midline;
            countDownText.SetText("Get Ready for your adventure ahead");
        }
        else if (countDownValue == 4)
        {
            GameController.instance.Set_CountDownStart();
            AudioController.instance.PlayCountDownAudio();
            AudioController.instance.SlowMoRaceMusic();
            countDownText.SetText("<size=10>Sit Tight</size>");
        }
        else if (countDownValue == 3)
        {
            countDownText.SetText("<size=10>On Your Mark</size>");
        }
        else if (countDownValue == 2)
        {
            countDownText.SetText("<size=10>Get Set</size>");
        }
        else if (countDownValue == 2)
        {
            countDownText.SetText("<size=10>Ready!</size>");
        }
        else if (countDownValue <= 0)
        {
            
            AudioController.instance.FixRaceMusic();
            countDownComplete = true;
            countDownText.SetText("<size=15>GO!</size>");
            GameDurationMili = 0;
            InvokeRepeating("GameTimeUpdateInvoker", 0, 0.01f);
            GameController.instance.Set_RaceStart();
        }
        
        countDownValue--;
    }
    public string GameTimeUpdateInvoker()
    {
		if (GameController.instance.GameOver)
			CancelInvoke ("GameTimeUpdateInvoker");
        string minute = ""+(GameDurationMili / 60000);
        string second = ""+((GameDurationMili % 60000) / 1000);
        string miliSecond = ""+(((GameDurationMili % 60000) % 1000) / 10);
        if (minute.Length < 2)
        {
            minute = "0" + minute;
        }
        if (second.Length < 2)
        {
            second = "0" + second;
        }
        if (miliSecond.Length < 2)
        {
            miliSecond = "0" + miliSecond;
        }
        GameDurationMili += 5;
        UI_Controller.instance.SetTimeTextDashboard(minute + ":" + second + ":" + miliSecond);
        return minute + ":" + second + ":" + miliSecond;
    }

    public string ConvertMili_To_String(float gameTimeMil)
    {
        string minute = "" + (int)(gameTimeMil / 60000);
        string second = "" + (int)((gameTimeMil % 60000) / 1000);
        string miliSecond = "" + (int)(((gameTimeMil % 60000) % 1000) / 10);
        if (minute.Length < 2)
        {
            minute = "0" + minute;
        }
        if (second.Length < 2)
        {
            second = "0" + second;
        }
        if (miliSecond.Length < 2)
        {
            miliSecond = "0" + miliSecond;
        }
        GameDurationMili += 5;
        UI_Controller.instance.SetTimeTextDashboard(minute + ":" + second + ":" + miliSecond);
        return minute + ":" + second + ":" + miliSecond;
    }
    public void SlowMoTime()
    {
        Time.timeScale = .5f;
        Invoke("FixSlowMoTime", 0.5f);
        AudioController.instance.SlowMoRaceMusic();
    }
    void FixSlowMoTime()
    {
        Time.timeScale = 1;
        AudioController.instance.FixRaceMusic();
    }

    

}
