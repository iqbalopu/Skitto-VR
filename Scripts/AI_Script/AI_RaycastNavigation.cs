using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_RaycastNavigation : MonoBehaviour
{

    public LayerMask Obstacle_SideCollideLayer;
    public LayerMask GroundLayer;
    public Transform RaycastOrigin, LeftSensor, RightSensor, CenterSensor,BottomSensor;

    // Left Variables
    Vector3 leftDirection;// = LeftSensor.position - RaycastOrigin.position;
    float LeftRayCastDistance;// = Vector3.Distance(RaycastOrigin.position, LeftSensor.position);
    // Use this for initialization
    Vector3 rightDirection;
    float rightRayCastDistance;

    Vector3 centerDirection;
    float centerRaycastDistance;

    Vector3 bottomDirection;
    float BottomDistance;

    public enum ColliderStatus { None,Front,Left,Right}
    public ColliderStatus currentStatus;
    
    private void Awake()
    {
        currentStatus = ColliderStatus.None;
    }
    void Start()
    {
        leftDirection = LeftSensor.position - RaycastOrigin.position;
        LeftRayCastDistance = Vector3.Distance(RaycastOrigin.position, LeftSensor.position);

        rightDirection = RightSensor.position - RaycastOrigin.position;
        rightRayCastDistance = Vector3.Distance(RaycastOrigin.position, RightSensor.position);

        centerDirection = CenterSensor.position - RaycastOrigin.position;
        centerRaycastDistance = Vector3.Distance(RaycastOrigin.position, CenterSensor.position);

        bottomDirection = BottomSensor.position - RaycastOrigin.position;
       BottomDistance = Vector3.Distance(RaycastOrigin.position, BottomSensor.position);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHittingWall(leftDirection, LeftRayCastDistance))
        {
            currentStatus = ColliderStatus.Left;
        }
        else if (isHittingWall(centerDirection, centerRaycastDistance))
        {
            currentStatus = ColliderStatus.Front;
        }
        else if (isHittingWall(rightDirection, rightRayCastDistance))
        {
            currentStatus = ColliderStatus.Right;
        }
        else
        {
            currentStatus = ColliderStatus.None;
        }

        RaycastHit hit;
        if (Physics.Raycast(RaycastOrigin.position, bottomDirection, out hit, BottomDistance, GroundLayer))
        {
            transform.up -= (transform.up - hit.normal) * .1f;
        }
    }
    public bool isHittingWall(Vector3 direction,float distance)
    {
        return Physics.Raycast(RaycastOrigin.position, direction, distance, Obstacle_SideCollideLayer);
    }
}
    
