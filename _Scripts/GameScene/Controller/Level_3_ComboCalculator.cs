using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_3_ComboCalculator : MonoBehaviour {

    float ft_last_cut_time;
    public float ft_maximum_time_gap;
    public Animator amt_combo;
    int nt_combo_counter;

    public static Level_3_ComboCalculator Instance;
    public bool isComboDetected;

    // Use this for initialization
	void Start () {
        Instance = this;
        isComboDetected = false;
        nt_combo_counter = 0;
	}

    public void CalculteCombo()
    {
        if ((Time.time - ft_last_cut_time) < ft_maximum_time_gap)
        {
            ++nt_combo_counter;
            // Update score here
            // Debug.LogError("Combo x = " + nt_combo_counter); 
            Invoke("checkEndCombo", ft_maximum_time_gap * 2);
        }

        ft_last_cut_time = Time.time;
    }

    public void checkEndCombo()
    {
        if (isComboDetected)
        {
            if (Time.time - ft_last_cut_time > ft_maximum_time_gap)
            {
                isComboDetected = false;
            }
        }

        if (!isComboDetected)
        {
            ResetCombo();
        }
    }

    public void ResetCombo()
    {
        if (nt_combo_counter > 0)
        {
            Level_3_UIController.Instance.SetCombo(nt_combo_counter);
            amt_combo.SetBool("Appear", true);
            Invoke("HideComboText", 2);
        }
        
        nt_combo_counter = 0;
        isComboDetected = false;
    }

    public void HideComboText()
    {
        if (!isComboDetected)
        {
            amt_combo.SetBool("Appear", false);
        }
    }
}