using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeAnimationController : MonoBehaviour {

    public Handlebar_InputCalculator handleInput;
    public Animator PlayerBikeAnimator;
    public BikeMovement bikeMovement;
    public Transform FrontWheel, RearWheel;
    private void Awake()
    {
        handleInput = GetComponent<Handlebar_InputCalculator>();
        bikeMovement = GetComponent<BikeMovement>();
    }
    // Update is called once per frame
	void Update () {
        PlayerBikeAnimator.SetFloat("Horizontal", -handleInput.Horizontal);
        PlayerBikeAnimator.SetFloat("Vertical", bikeMovement.getSpeedRatio());
        FrontWheel.Rotate(Vector3.right * bikeMovement.speed);
        RearWheel.Rotate(Vector3.right * bikeMovement.speed);
    }
}
