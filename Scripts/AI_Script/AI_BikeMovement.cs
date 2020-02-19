using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BikeMovement : MonoBehaviour {

    public bool AI_Reached_End;

    public bool isGrounded = false;
    Rigidbody rigidbodyC;
    
    AI_RaycastNavigation aiNavigation;
    AI_BikeAnimation ai_BikeAnimation;
    AI_Effects ai_Effect;

    public float MaxForwardSpeed = 70;
    public float speed;
    private void Awake()
    {
        rigidbodyC = GetComponent<Rigidbody>();
        aiNavigation = GetComponent<AI_RaycastNavigation>();
        ai_BikeAnimation = GetComponent<AI_BikeAnimation>();
        ai_Effect = GetComponent<AI_Effects>();
    }
    // Use this for initialization
    void Start () {
        AI_Reached_End = false;
	}

    float maxAngle = 45;
	
	// Update is called once per frame
	void Update () {

        if (GameController.instance.RaceStart && !GameController.instance.GameOver && !AI_Reached_End)
        {
            ai_Effect.PlayThurstParticle();
            if (aiNavigation.currentStatus == AI_RaycastNavigation.ColliderStatus.Front
                        || aiNavigation.currentStatus == AI_RaycastNavigation.ColliderStatus.Right)
            {
                transform.Translate(Vector3.left * .1f);
                ai_BikeAnimation.SetDirection(-1);
                speed = Mathf.Lerp(speed, 5, Time.deltaTime);
            }
            else if (aiNavigation.currentStatus == AI_RaycastNavigation.ColliderStatus.Left)
            {
                transform.Translate(Vector3.right * .1f);
                ai_BikeAnimation.SetDirection(1);
                speed = Mathf.Lerp(speed, 5, Time.deltaTime);
            }

            else if (aiNavigation.currentStatus == AI_RaycastNavigation.ColliderStatus.None)
            {
                speed = Mathf.Lerp(speed, MaxForwardSpeed, Time.deltaTime);
                ai_BikeAnimation.SetDirection(0);
            }
            Vector3 velocity = Vector3.forward;
            if (!isGrounded)
            {
                velocity.y = -10 * Time.deltaTime;
            }
            rigidbodyC.velocity = velocity * speed;
        }
        else
        {
            ai_Effect.StopThrustParticle();
            speed = Mathf.Lerp(speed, 0, Time.deltaTime);
            rigidbodyC.velocity = Vector3.forward*speed;
        }
        if (transform.position.y < -50)
        {
            transform.position = new Vector3(0, 30, transform.position.z);
        }
        

        


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
