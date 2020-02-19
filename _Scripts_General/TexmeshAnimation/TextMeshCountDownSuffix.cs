using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshCountDownSuffix : MonoBehaviour {

    public bool showBeforeCountDown;
    public bool showAfterCountDown;
    

    public string Prefix;
    public string Suffix;

    public int StartingValue;
    public int FinishingValue;
    
    public float Duration;

    float interval;
    float currentValue;
    float fraction = 0;
    TextMeshPro textMeshPro;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }
    private void Start()
    {
        if (!showBeforeCountDown)
        {
            textMeshPro.text = "";
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //StartCountDown();
        }
    }
    public void StartCountDown(int StartingValue, int FinishingValue, float Duration, string Prefix, string Suffix)
    {
        
        this.StartingValue = StartingValue;
        this.FinishingValue = FinishingValue;
        this.Duration = Duration;

        this.Suffix = Suffix;
        this.Prefix = Prefix;

        currentValue = StartingValue;

        fraction = (FinishingValue > StartingValue)?1:-1;
        interval = Duration/Mathf.Abs(FinishingValue -StartingValue);
        InvokeRepeating("UpdateCountDownValue", 0, interval);
    }
    void UpdateCountDownValue()
    {
        textMeshPro.text = Prefix + currentValue + Suffix;
        
        if ((int)currentValue == FinishingValue)
        {
            if (!showAfterCountDown)
            {
                textMeshPro.text = "";
            }
            CancelInvoke("UpdateCountDownValue");

        }
        currentValue += fraction;

    }
   
}
