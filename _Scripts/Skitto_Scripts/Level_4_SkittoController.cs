using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SkittoController : MonoBehaviour {

    Level_4_SkittoAnimation skittoAnimation;
    Level_4_SkittoAudio skittoAudio;
    Level_4_SkittoLookAt skittoLookAt;
    Level_4_SkittoMovement skittoMovement;
    public Transform snakeEatDestination;
    public Transform fistBumpDestination;
    public Transform StartPosition;
    private void Awake()
    {
        skittoAnimation = GetComponent<Level_4_SkittoAnimation>();
        skittoAudio = GetComponent<Level_4_SkittoAudio>();
        skittoMovement = GetComponent<Level_4_SkittoMovement>();
        skittoLookAt = GetComponent<Level_4_SkittoLookAt>();
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.gameTimeOn)
        {
            skittoAnimation.Play_SetCheer_Cover_Awesome();
        }
    }

}
