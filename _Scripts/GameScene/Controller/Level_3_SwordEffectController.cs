using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_SwordEffectController : MonoBehaviour {

    public static Level_3_SwordEffectController instance;

    private void Awake()
    {
        instance = this;
    }
}