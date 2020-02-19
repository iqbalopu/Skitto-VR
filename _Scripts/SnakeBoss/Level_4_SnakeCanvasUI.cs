using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_4_SnakeCanvasUI : MonoBehaviour {

    public Image snakeHealthBar;
    Level_4_SnakeStatus snakestatus;
    private void Awake()
    {
        snakestatus = GetComponentInParent<Level_4_SnakeStatus>();
    }
    private void Start()
    {
        snakeHealthBar.fillAmount = snakestatus.Life;
    }
    public void DecreaseLife()
    {
        snakeHealthBar.fillAmount = snakestatus.Life;
    }
}
