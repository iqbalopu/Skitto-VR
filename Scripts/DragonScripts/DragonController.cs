using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour {

    public float Z_Offset= 3;
    public float X_Offset= 12;
    public float zPing;
    public float xPing;
    public static DragonController instance;

    public Transform PlayerTransform;
    public Animator DragonHolderAnimator;

    public bool startFollowing;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        startFollowing = false;
    }
    private void Update()
    {
        if (startFollowing)
        {
            zPing = Z_Offset+Mathf.PingPong(Time.time*5, 34);
            xPing = -X_Offset + Mathf.PingPong(Time.time, X_Offset*2);
            //float xPing = Z_Offset + Mathf.PingPong(Time.time, 17);
            Vector3 targetPosition = new Vector3(PlayerTransform.position.x + xPing, transform.position.y, PlayerTransform.position.z + zPing);
            transform.position = targetPosition;// Vector3.Lerp(transform.position,targetPosition,Time.deltaTime*10);
        }
    }
    public void SetStartFollowing()
    {
        startFollowing = true;
        DragonHolderAnimator.SetBool("Fwd", true);
    }
    public void StopFollowing()
    {
        startFollowing = false;
        DragonHolderAnimator.SetBool("Fwd", false);
    }
}
