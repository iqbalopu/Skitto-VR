using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_LookAtCubePositionController : MonoBehaviour {
    public Transform cameraHeadTransform;
    Transform thisTransform;
    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        thisTransform.position = new Vector3(cameraHeadTransform.position.x,thisTransform.position.y,cameraHeadTransform.position.z);

	}
}
