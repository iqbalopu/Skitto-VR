using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_BatEffects : MonoBehaviour {

    public ParticleSystem batDestroyParticle;
    private void Awake()
    {
        batDestroyParticle = GetComponentInChildren<ParticleSystem>();
    }
    public void PlayBatDestroyParticle()
    {
      
        batDestroyParticle.Play();
    }
}
