using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeExplosive : MonoBehaviour {

    ParticleSystem ExplosiveDestroyParticle;
    public ParticleSystem ShieldParticle;
    private void Awake()
    {
        ExplosiveDestroyParticle = GetComponentInChildren<ParticleSystem>();
        canMove = false;
        directionToPlayer = new Vector3();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Explode particle
            //Debug.Log("__________Hit Ground_________");
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            canMove = false;
            GetComponent<Rigidbody>().isKinematic = true;

            Invoke("DestroyObject_Invoke", 1.5f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            ExplosiveDestroyParticle.Play();
            canMove = false;
            Debug.Log("----------Hit Bullet------------");
            Invoke("DestroyObject_Invoke", 1.5f);
            
        }
        if(collision.gameObject.CompareTag("Shield"))
        {
            //GetComponent<Renderer>().enabled = false;
            //GetComponent<Collider>().enabled = false;
            //GetComponent<Rigidbody>().isKinematic = true;
            //collision.gameObject.GetComponent<Level_4_PlayerShield>().PlayShieldParticle();
            canMove = false;
            Debug.Log("_____________Has hit the shield______________");
            Invoke("DestroyObject_Invoke", 2f);
        }
        //Debug.Log("Collided with: " + collision.gameObject.name);
    }
    Vector3 directionToPlayer;
    bool canMove=false;
    public void SetDirection(Vector3 directionToPlayer)
    {
        this.directionToPlayer = directionToPlayer;
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            transform.Translate(directionToPlayer * Time.deltaTime/4);
        }
    }

    void DestroyObject_Invoke()
    {
        Destroy(this.gameObject);
    }
}
