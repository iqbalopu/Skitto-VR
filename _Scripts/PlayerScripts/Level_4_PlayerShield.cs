using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_PlayerShield : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private SteamVR_TrackedController controller;
    public GameObject controllerLeft;
    public Animator PlayerHealthAnim;
    //public ParticleSystem ShieldParticle;
    private void Awake()
    {
        
        controller = controllerLeft.GetComponent<SteamVR_TrackedController>();
        trackedObj = controllerLeft.GetComponent<SteamVR_TrackedObject>();
    }
    private void Start()
    {
        controller.TriggerClicked += TriggerPressed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse((1));
        if(collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }

    }
    //public void PlayShieldParticle()
    //{
    //    ShieldParticle.Play();
    //}
    private void TriggerPressed(object sender, ClickedEventArgs e)
    {

        //Debug.LogWarning("Object Sender name: " + sender);
        //Debug.LogWarning("Click Event Arguments: " + e);
        //ShowHealthBar();
    }
    //public void ShowHealthBar()
    //{
    //    PlayerHealthAnim.SetTrigger("Appear");
    //}

}
