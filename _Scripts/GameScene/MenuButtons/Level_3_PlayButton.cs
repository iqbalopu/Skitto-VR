using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level_3_PlayButton : MonoBehaviour {

    public bool isButtonPressed = false;
    public bool isButtonEnabled = false;
    public int nt_level_to_be_loaded = 1;
    public TextMeshPro txt_score, txt_high_score;

    private void Start()
    {
        txt_score.text = "Score: " + PlayerPrefs.GetInt("score", 0).ToString();
        txt_high_score.text = "Best: " + PlayerPrefs.GetInt("HighestScore", 0).ToString();
        isButtonEnabled = false;

        Invoke("EnableButton", 1.2f);
    }

    public void EnableButton()
    {
        isButtonEnabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword") && !isButtonPressed && isButtonEnabled)
        {
            isButtonPressed = true;
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Animator>().SetTrigger("Hit");
            Level_3_AudioManager.instance.PlayDong();
            Invoke("LoadLevel", 3.0f);
        }
    }

    public void LoadLevel()
    {
        // Debug.LogError("Sword pressed Home Button");
        //Application.LoadLevel(nt_level_to_be_loaded);
        // gameObject.SetActive(false);
        SceneManager.LoadScene(nt_level_to_be_loaded);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}