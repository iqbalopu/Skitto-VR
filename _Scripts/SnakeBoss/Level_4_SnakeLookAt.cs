using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeLookAt : MonoBehaviour {
    Transform thisTransform;
    Vector3 lookAtVector;// = SnakeBoss.GetComponent<Level_4_SnakeStatus>().PlayerTransform.position;
    Level_4_SnakeStatus snake;
    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
        snake = GetComponentInChildren<Level_4_SnakeStatus>();

    }
    private void Update()
    {
        lookAtVector = snake.PlayerTransform.position;

        thisTransform.LookAt(lookAtVector);
    }
}
