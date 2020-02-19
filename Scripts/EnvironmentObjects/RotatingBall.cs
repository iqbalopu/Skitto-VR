using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBall : MonoBehaviour {

    public Transform rotationCenter;
    float rotationSpeed;
	// Use this for initialization
	void Awake () {
        rotationCenter = transform.parent;
        rotationSpeed = Random.Range(90, 120);
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(rotationCenter.position, Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
