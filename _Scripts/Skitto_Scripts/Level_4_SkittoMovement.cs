using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SkittoMovement : MonoBehaviour {
    #region ______Public Variables______
    [Header("_____float Variables_____")]
    public float moveSpeed;
    [Header("_____TrailRenderer Variables_____")]
    public TrailRenderer skittoTrail;
    #endregion
#region
    Transform thisTransform;
    Level_4_SkittoController skittoController;
    Level_4_SkittoAnimation skittoAnimation;
    Level_4_SkittoLookAt skittoLookAt;
    Level_4_Skitto_DialogAnimator DialogAnimator;
    #endregion
#region ______Private Methods______
    private void Awake()
    {
        skittoController = GetComponent<Level_4_SkittoController>();
        skittoAnimation = GetComponent<Level_4_SkittoAnimation>();
        thisTransform = GetComponent<Transform>();
        DialogAnimator = GetComponentInChildren<Level_4_Skitto_DialogAnimator>();
        skittoLookAt = GetComponent<Level_4_SkittoLookAt>();
        skittoTrail.enabled = false;
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.jilapiDead)
        {
            DialogAnimator.SetEndAnimation();
            skittoAnimation.TriggerIdlePose();
        }
        if (Level_4_GameTimeController.instance.eatSnake)
        {
            skittoTrail.enabled = true;
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, skittoController.snakeEatDestination.position, Time.deltaTime * moveSpeed);
            skittoAnimation.Play_Skitto_Fly();
            if(Vector3.Distance(thisTransform.position,skittoController.snakeEatDestination.position)<0.2f)
            {
                skittoAnimation.Play_Skitto_Idle();
                transform.localScale = new Vector3(0, 0, 0);
                skittoTrail.enabled = false;
                Level_4_GameTimeController.instance.eatSnake = false;
            }
        }
        if(Level_4_GameTimeController.instance.fistBump)
        {
            transform.localScale = new Vector3(1, 1, 1);
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, skittoController.fistBumpDestination.position, Time.deltaTime * moveSpeed);
            skittoAnimation.Play_Skitto_Fly();
            skittoController.fistBumpDestination.GetComponent<Level_4_SkittoEndingPositioner>().CalCulatePositin();
            if (Vector3.Distance(thisTransform.position, skittoController.fistBumpDestination.position)<0.01f)
            {
                skittoAnimation.Play_Skitto_fistBumpWait();
                skittoAnimation.Play_FistBumpDialougeAppear();
                Level_4_GameTimeController.instance.fistBump = false;
                Level_4_GameTimeController.instance.getFistBump = true;
            }
        }
        if(Level_4_GameTimeController.instance.MoveToStart)
        {
            //skittoTrail.enabled = true;
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, skittoController.StartPosition.position, Time.deltaTime * (moveSpeed/2 ));
            skittoAnimation.Play_Skitto_Fly();
            if (Vector3.Distance(thisTransform.position, skittoController.StartPosition.position) < 0.2f)
            {
                Level_4_GameTimeController.instance.getFistBump = false;
                skittoLookAt.LookAtPlayer();
            }
        }
    }
#endregion
}
