using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeAnimation : MonoBehaviour {

    Animator snakAnimation;
    // Use this for initialization
    private void Awake()
    {
        snakAnimation = GetComponent<Animator>();
    }

    public void SnakeMove()
    {
        snakAnimation.SetBool("walk", true);
    }
    public void PlayDamage()
    {
        snakAnimation.SetFloat("damageSpeed",0.5f+Random.Range(0.10f,1f));
        snakAnimation.SetTrigger("damage");
    }
    public void SnakeIdle()
    {
        snakAnimation.SetBool("walk", false);
    }
    public void PlayAttack()
    {
        //Debug.Log("______________PlayAttack_________________");
        snakAnimation.SetTrigger("attack");
    }
    public void PlayDead()
    {
        snakAnimation.SetBool("dead", true);
    }
    public void Play_DeathVibration()
    {
        snakAnimation.SetBool("deathVibration", true);
    }
}
