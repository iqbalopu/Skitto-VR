using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortoCarMovement : MonoBehaviour {

    public ParticleSystem ExplosionParticle;
    public bool StartMoving = false;
    public float initialZ;
    public float Speed;

    public Animator CarAnimation;
    private void Start()
    {
        StartMoving = false;
        initialZ = transform.position.z;
    }

    public void Set_StartMoving()
    {
        StartMoving = true;
    }
    public void StopMoving()
    {
        ExplosionParticle.Play();
        StartMoving = false;
        CarAnimation.SetTrigger("Accident");
        AudioController.instance.PlayAccidentSound();
    }
    // Update is called once per frame
    void Update () {
        if (StartMoving)
        {
            if (Mathf.Abs(transform.position.z - initialZ) < 50)
            {
                transform.Translate(Vector3.forward * Time.deltaTime*Speed);
            }
        }
	}
}
