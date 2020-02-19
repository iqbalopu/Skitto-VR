using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BIKE_AI_Position : MonoBehaviour {

    public static BIKE_AI_Position instance;
    private void Awake()
    {
        instance = this;
    }
    public Transform PlayerBike;
    public TextMeshPro totalBike, CurrentPositionText;
    public Transform[] allAI;
    private void Start()
    {
        InvokeRepeating("CheckPostion", 0, 1);
        totalBike.text = "/" + (allAI.Length + 1);
    }
    public void SetGameOver()
    {
        CancelInvoke("CheckPostion");
		CurrentPositionText.text = "";
        UI_Controller.instance.SetPosition(CheckPostion());
    }
    public int CheckPostion()
    {
        int currentPosition = 0;
        for (int i = 0; i < allAI.Length; i++)
        {
            if (PlayerBike.position.z < allAI[i].position.z)
            {
                currentPosition++;
            }
        }
        CurrentPositionText.text = "" + (currentPosition+1);
        return (currentPosition + 1);
    }
}
