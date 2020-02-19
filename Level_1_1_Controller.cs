using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_1_Controller : MonoBehaviour {
    public Animator Level_1_1_Animator;
    public ParticleSystem DoorOpenParticle;
    private void Awake()
    {
        Level_1_1_Animator= GetComponent<Animator>();
    }
    private void Start()
    {
        Invoke("SetTrigger_Invoke", 1f);
    }
    void SetTrigger_Invoke()
    {
        Level_1_1_Animator.SetTrigger("Move");
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Level_1_1_Animator.SetTrigger("Move");

    //    }
    //}
    public void PlayDoorOpenParticle()
    {
        DoorOpenParticle.Play();
    }
    public void LoadNextLevel()
    {
        //Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        LevelChangeController.instance.LoadNextLevel(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
    }
}
