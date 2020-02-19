using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeMovement : MonoBehaviour {
    #region ________Public Variables________
    [Header("_____Transform Variables_____")]
    public Transform SnakePositionHolder;
    [Header("_____List Variables______")]
    public List<Transform> AllPositions;
    [Header("_____Vector3 Variables______")]
    public Vector3 TargetPosition;
    [Header("_____Integer Variables_____")]
    public int targetPositionIndex;
    [Header("_____Float Variables_____")]
    public float moveSpeed = 20f;
    [Header("_____GameObject Variables_____")]
    public GameObject JilapiBoss;
    #endregion
    #region ________Private Variables________
    Transform thisTransform;
    Level_4_SnakeAnimation snakeAnimation;
    Level_4_SnakeStatus snakeStatus;
    Level_4_SnakeAudio snakeAudio;
    #endregion

#region _________Private Methods__________
    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
        snakeAnimation = GetComponentInChildren<Level_4_SnakeAnimation>();
        snakeStatus = GetComponentInChildren<Level_4_SnakeStatus>();
        snakeAudio = GetComponentInChildren<Level_4_SnakeAudio>();
    }
    // Use this for initialization
    void Start()
    {
        targetPositionIndex = 2;
        AllPositions = new List<Transform>();
        foreach (Transform t in SnakePositionHolder)
        {
            AllPositions.Add(t);
        }
        TargetPosition = AllPositions[targetPositionIndex].position;
        InvokeRepeating("PositionUpdate_InvokeR", 0,9);
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.gameTimeOn)
        {
            if (!snakeStatus.isDead)
            {
                snakeAudio.Play_SnakeIdleAudio();
                if (!snakeStatus.isDamaged)
                {
                    if (Vector3.Distance(thisTransform.position, TargetPosition) > 1)
                    {
                        if (snakeStatus.isIdle)
                        {
                            CancelInvoke("Attack_InvokeR");
                            snakeAnimation.SnakeMove();
                            snakeStatus.isIdle = false;
                            //Debug.Log("start moving"); // stop firing
                        }
                    }
                    else
                    {
                        if (!snakeStatus.isIdle)
                        {
                            // Debug.Log("at idle");// now attack
                            snakeAnimation.SnakeIdle();
                            snakeStatus.isIdle = true;
                            InvokeRepeating("Attack_InvokeR", 2, 2);
                        }
                    }
                }
                if (!snakeStatus.isDamaged)
                {
                    thisTransform.position = Vector3.MoveTowards(thisTransform.position, TargetPosition, Time.deltaTime * moveSpeed);
                }
            }
            else
            {
                this.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
            }
        }
        else
        {
            TargetPosition = AllPositions[2].position;
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, TargetPosition, Time.deltaTime * moveSpeed);
            CancelInvoke("Attack_InvokeR");
        }
    }
    private void PositionUpdate_InvokeR()
    {
        targetPositionIndex = Random.Range(0, AllPositions.Count);
        TargetPosition = AllPositions[targetPositionIndex].position;
    }
#endregion
    #region ________Public Methods________
    public void Attack_InvokeR()
    {
        snakeAnimation.PlayAttack();
    }
    public void CanclePositionUpdateInvoke()
    {
        CancelInvoke("PositionUpdate_InvokeR");
    }
#endregion
}