using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Canon : MonoBehaviour {

    private Animator amt_canon;
    public ParticleSystem p;

    private void Awake()
    {
        amt_canon = GetComponent<Animator>();
        p = GetComponentInChildren<ParticleSystem>();
    }

    public void fire()
    {
        amt_canon.SetTrigger("fire");
        p.Play();
        // Debug.Log("Fire Called"); 
        Level_3_AudioManager.instance.PlayBloop();
    }
}