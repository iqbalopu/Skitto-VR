using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeCollision : MonoBehaviour {

    public bool isGrounded = false;
    public BikeAudioController bikeAudioController;
    public BikeMovement bikeMovement;
    private void Awake()
    {
        bikeAudioController = GetComponent<BikeAudioController>();
        bikeMovement = GetComponent<BikeMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bikeAudioController.PlayGroundCollision();
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("SideCollider"))
        {
            bikeAudioController.PlaySideCollision();
            //Debug.LogWarning("Collision at: "+(collision.contacts[0].point.x - transform.position.x));
            if (collision.contacts[0].point.x > transform.position.x)
            {
                bikeMovement.bikeEffect.PlaySpark(1);
            }
            else
            {
                bikeMovement.bikeEffect.PlaySpark(-1);
            }
        }
        if (collision.gameObject.CompareTag("MovingObstacle"))
        {
            bikeMovement.ReduceSpeed();
        }
        if (collision.gameObject.CompareTag("ShortoCarCollider"))
        {
            bikeMovement.ReduceSpeed();
            collision.gameObject.GetComponentInParent<ShortoCarMovement>().StopMoving();
            GameTimeController.instance.SlowMoTime();
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
