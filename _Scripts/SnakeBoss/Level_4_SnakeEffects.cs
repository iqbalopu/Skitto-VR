using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeEffects : MonoBehaviour {

    public ParticleSystem AttackParticle;
    public ParticleSystem HurtParticle;
    public ParticleSystem DropParticle;
    public ParticleSystem ShieldParticle;
    public void PlayAttackParticle()
    {
        AttackParticle.Play();
    }
    public void PlayHurtParticle()
    {
        HurtParticle.Play();
    }
    public void PlayDropParticle()
    {
        DropParticle.Play();
    }
    public void PlayShieldParticle()
    {
        ShieldParticle.Play();
    }
    public void StopShieldParticle()
    {
        ShieldParticle.Stop();
    }
}
