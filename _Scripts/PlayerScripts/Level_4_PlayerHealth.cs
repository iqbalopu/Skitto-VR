using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_4_PlayerHealth : MonoBehaviour {
    public TextMeshPro playerHeathText;
    public float PlayerLife;
    int lifestringLength;
    private void Start()
    {
        PlayerLife = 1;
        playerHeathText.text = "IIIIIIIIIIIIIIIIII";
        lifestringLength = playerHeathText.text.Length-1;
    }
    private void Update()
    {
        if(PlayerLife<(1f/15f))
        {
            Level_4_GameTimeController.instance.gameTimeOn = false;
            Level_4_GameTimeController.instance.gameOver = true;
            Level_4_GameTimeController.instance.ShowGameOverPanel_PlayerDead();
        }
    }
    public void GetDamaged()
    {
        PlayerLife -= (1f / 21f);
        //Play player Damage Audio
        //Set set player healthText
        Debug.Log("__________________Player Damaged__________________");
        DecreasePlayerHealth();
    }
    public void DecreasePlayerHealth()
    {
        lifestringLength--;
        playerHeathText.text = playerHeathText.text.Substring(0, lifestringLength);
    }
}
