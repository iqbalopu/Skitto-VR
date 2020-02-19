using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_GameController : MonoBehaviour {

    public GameObject Player;
    
    public static Level_4_GameController instance;
    private void Awake()
    {
        instance = this;
    }

    public void SetGameOver()
    {
        Player.GetComponent<Level_4_PlayerHandShower>().ShowHands();
    }
    
}
