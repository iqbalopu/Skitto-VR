using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SkittoLookAt : MonoBehaviour {

    Level_4_SkittoController skittoController;
    public Transform Player;
    Transform thisTransform;
    Vector3 lookAtVector;
    public Transform StartPosition;
    public Transform looEatSnake;
    private void Awake()
    {
        skittoController = GetComponent<Level_4_SkittoController>();
        thisTransform = GetComponent<Transform>();
        
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.eatSnake)
        {
            lookAtVector = looEatSnake.position;
            thisTransform.LookAt(lookAtVector);
        }
        if(Level_4_GameTimeController.instance.fistBump)
        {
            lookAtVector = skittoController.fistBumpDestination.position;
            thisTransform.LookAt(lookAtVector);
        }
        if(Level_4_GameTimeController.instance.getFistBump)
        {
            lookAtVector = Player.position;
            
            thisTransform.LookAt(lookAtVector);
        }
        if(Level_4_GameTimeController.instance.MoveToStart)
        {
            lookAtVector = StartPosition.position;
            thisTransform.LookAt(lookAtVector);
        }
    }
    public void LookAtPlayer()
    {
        lookAtVector = Player.position;
        thisTransform.LookAt(lookAtVector);
    }
}
