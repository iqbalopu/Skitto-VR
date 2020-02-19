using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_PlayerControllerRightCollision : MonoBehaviour {
    public GameObject skittoBot;
    public ParticleSystem fistBumpParticle;
    BoxCollider handCollider;
    Level_4_SkittoAnimation skittoAnimation;
    private void Awake()
    {
        skittoAnimation = skittoBot.GetComponent<Level_4_SkittoAnimation>();
        handCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        handCollider.enabled = false;
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.getFistBump)
        {
            handCollider.enabled = true;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("skittoHand"))
    //    {
    //        skittoAnimation.Play_skitto_fistBumpDone();
    //        Level_4_GameTimeController.instance.gameOver = true;
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("skittoHand"))
        {
            skittoAnimation.Play_skitto_fistBumpDone();
            skittoAnimation.Play_FistBumpDialougeDisappear();
            fistBumpParticle.Play();
            //Debug.Log("__________________Triggred FistBump_________________");
            Level_4_GameTimeController.instance.gameOver = true;
            Level_4_GameTimeController.instance.OnGameOver();
        }
    }
}
