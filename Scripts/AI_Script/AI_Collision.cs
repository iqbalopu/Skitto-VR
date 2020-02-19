using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Collision : MonoBehaviour {

    public float collisionTime = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingObstacle"))
        {
            collisionTime = 0;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingObstacle"))
        {
            collisionTime += Time.deltaTime;
            if (collisionTime > 3)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z - 10);
                collisionTime = 0;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingObstacle"))
        {
            collisionTime = 0;
        }
    }

}
