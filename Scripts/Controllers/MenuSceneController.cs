using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuSceneController : MonoBehaviour {

	public TextMeshPro BestTimeText;
	public Animator PlayerCameraRigAnimator;
	public bool mainMenuButtonPressed=false;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey("GameDurationMili"))
		{
			PlayerPrefs.SetFloat("GameDurationMili",9999999);
		}

		BestTimeText.text = ConvertMili_To_String(PlayerPrefs.GetFloat("GameDurationMili"));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)&& !mainMenuButtonPressed) 
		{
			PlayerCameraRigAnimator.SetBool ("StartGame", true);
			Invoke ("GoToGameMenu", 5);
			mainMenuButtonPressed = true;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}
	void GoToGameMenu()
	{
		SceneManager.LoadScene (1);
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

		return minute + ":" + second + ":" + miliSecond;
	}
}
