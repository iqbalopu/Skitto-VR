using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Effects : MonoBehaviour {

    public ParticleSystem ThrustParticle;
    public void PlayThurstParticle()
    {
        if (!ThrustParticle.isPlaying) {
            ThrustParticle.Play();
        }
    }
    public void StopThrustParticle()
    {
        if (ThrustParticle.isPlaying)
        {
            ThrustParticle.Stop();
        }
    }
}
