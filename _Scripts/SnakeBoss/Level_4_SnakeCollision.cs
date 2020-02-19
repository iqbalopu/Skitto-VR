using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeCollision : MonoBehaviour {
    int HitCount;
    Level_4_SnakeStatus snakeStatus;
    Level_4_SnakeEffects snakeEffects;
    private void Awake()
    {
        snakeStatus = GetComponentInParent<Level_4_SnakeStatus>();
        snakeEffects = GetComponentInParent<Level_4_SnakeEffects>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")&& HitCount<2)
        {
            //Debug.Log("________________Hit by Bullet__________________");
            snakeStatus.GettingDamage();
            HitCount++;
            if(HitCount==2)
            {
                snakeEffects.PlayShieldParticle();
                Invoke("ResetHitCount_Invoke", 5f);
            }
        }
    }
    void ResetHitCount_Invoke()
    {
        HitCount = 0;
        snakeEffects.StopShieldParticle();
    }
}
