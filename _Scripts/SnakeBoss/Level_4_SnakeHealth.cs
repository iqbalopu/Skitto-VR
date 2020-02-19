using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_4_SnakeHealth : MonoBehaviour {

    public Animator snakeHealthAnim;
    public TextMeshPro healthText;
    int stringLength;
    private void Start()
    {
        healthText.text = "IIIIIIIIIIIIIIIIIIII";
        stringLength = healthText.text.Length;
        Debug.Log("Snake String Length: " + stringLength);
    }
    public void PlayAppear()
    {
        snakeHealthAnim.SetTrigger("Appear");
    }
    public void DecreaseHelthText()
    {

        stringLength--;
        if(stringLength>0)
        {
            healthText.text = healthText.text.Substring(0, stringLength);
        }
    }
	
}
