using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeReposition : MonoBehaviour {
    public Transform CameraReference;
    public Transform LeftControllerReference,RightControllerReference;
    public CapsuleCollider playerCapsuleCollider;

    public Transform LeftHandleBar, RightHandleBar;

    public Animator CameraRigAnimator;

    
    // Use this for initialization
    void Start () {
        //Invoke("Reposition", 1);
        GameController.instance.OnCountDownStart += OnCountDownStart;
	}
    IEnumerator Reposition()
    {
        CameraRigAnimator.enabled = false;
        if( GetComponentInParent<Handlebar_InputCalculator>().KeyboardInput)
        {
            CameraRigAnimator.transform.position = new Vector3(CameraRigAnimator.transform.position.x, 2, CameraRigAnimator.transform.position.z);
        }
        Vector3 targetPos = new Vector3(CameraReference.position.x, transform.position.y, CameraReference.position.z);
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            //transform.position = new Vector3(CameraReference.position.x, transform.position.y, CameraReference.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*5);
            yield return new WaitForEndOfFrame();
        }
        
       // playerCapsuleCollider.center = new Vector3(transform.position.x, playerCapsuleCollider.center.y, transform.position.z);
    }
    void OnCountDownStart()// GameController tells u
    {
        StartCoroutine(Reposition());
    }
    public void ForceReposition()
    {
        Vector3 targetPos = new Vector3(CameraReference.position.x, transform.position.y, CameraReference.position.z);
        transform.position = targetPos;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&& GameController.instance.RaceStart)
        {
            ForceReposition();
        }
        LeftHandleBar.rotation = LeftControllerReference.rotation;
        RightHandleBar.rotation = RightControllerReference.rotation;
        playerCapsuleCollider.center = new Vector3(transform.localPosition.x, playerCapsuleCollider.center.y, transform.localPosition.z);
    }
}
