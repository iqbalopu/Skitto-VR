using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENM_BladeColor
{
    enm_Fire,enm_Freeze,enm_Normal
}

public class Level_3_SwordTrailColor : MonoBehaviour {
    
    public Gradient FireColor;
    public Gradient FreezeColor;
    public Gradient NormalColor;

    public void SetBladeTrailColor(ENM_BladeColor BladeColor)
    {
        switch (BladeColor)
        {
            case ENM_BladeColor.enm_Fire:
                GetComponent<TrailRenderer>().colorGradient = FireColor;
                break;
            case ENM_BladeColor.enm_Freeze:
                GetComponent<TrailRenderer>().colorGradient = FreezeColor;
                break;
            case ENM_BladeColor.enm_Normal:
                GetComponent<TrailRenderer>().colorGradient = NormalColor;
                break;
            default:
                GetComponent<TrailRenderer>().colorGradient = NormalColor;
                break;
        }
    }
}