using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Fruit : MonoBehaviour {
    /*
     Tags used
     Ground
     Fruits -> Tag-> Fruit Layer-> Fruit
     sword -Tag -> sword
     camera rig-> Camera (head) Tag-> MainCamera

         */
    public enum FruitType
    {
        normal,
        bomb,
        fire,
        freeze,
        Double,
        Mula,
        Bangi,
        Kachkola,
        Kathal
    }

    #region Component
    public Rigidbody rigidbody;
    public BoxCollider boxCollider;
    public Transform transform;
    public MeshRenderer meshRenderer;
    public Animator amt_bomb_scale;
    #endregion

    #region Child_ FruitHalves
    public Level_3_FruitHalf[] allFruitHavles;
    //public ParticleSystem[] allParticles;

    public ParticleSystem GeneralParticle;
    public ParticleSystem Fire_Particle;
    public ParticleSystem Freeze_Particle;
    public ParticleSystem BOOM_Particle;
    public ParticleSystem EDGE_Particle;

    #endregion

    #region PublicVariable
    public bool isFruitPicked;
    private Transform tr_fruit_half;
    public FruitType type = FruitType.normal;
    public bool isGrounded = false;
    #endregion

    private void Awake()
    {
        transform       = GetComponent<Transform>();
        rigidbody       = GetComponent<Rigidbody>();
        boxCollider     = GetComponent<BoxCollider>();
        meshRenderer    = GetComponent<MeshRenderer>();
        allFruitHavles  = GetComponentsInChildren<Level_3_FruitHalf>();
        
        if (type == FruitType.bomb) {
            BOOM_Particle = transform.Find("BOOM").GetComponent<ParticleSystem>();
            EDGE_Particle = transform.Find("EDGE").GetComponent<ParticleSystem>();
            amt_bomb_scale = GetComponent<Animator>();
        } else {
                GeneralParticle     = transform.Find("Splash").GetComponent<ParticleSystem>();
                Fire_Particle       = transform.Find("Fire").  GetComponent<ParticleSystem>();
                Freeze_Particle     = transform.Find("Freeze").GetComponent<ParticleSystem>();
        }
    }

    public void SetupBombParticle()
    {
        BOOM_Particle = transform.Find("BOOM").GetComponent<ParticleSystem>();
        EDGE_Particle = transform.Find("EDGE").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        Disable(); 
        // Debug.LogError("Calling from start"); 
    }
    
    public virtual void Enable(Vector3 position, Vector3 force)
    {
        isFruitPicked           = true;
        transform.position      = position;
        meshRenderer.enabled    = true;
        rigidbody.isKinematic   = false;
        boxCollider.enabled     = true;
        rigidbody.AddForce(force);
        isGrounded              = false;
        rigidbody.AddTorque(new Vector3(getRandom(), 
                                        getRandom(), 
                                        getRandom()));
        if (type == FruitType.fire || 
            type == FruitType.freeze) {
            PlayGeneralParticle();
        }

        if (type == FruitType.bomb)
        {
            amt_bomb_scale.SetBool("scaleup", true);
        }
    }

    public float getRandom() {
        return Random.Range(-60, 60);
    }

    public virtual void Disable() // Called when grounded
    {
        isFruitPicked           = false;
        meshRenderer.enabled    = false;
        rigidbody.isKinematic   =  true;
        boxCollider.enabled     = false;

        //if (type == FruitType.fire || 
        //    type == FruitType.freeze) {
        //    StopGeneralParticle();
        //}

        //if (type == FruitType.bomb)
        //{
        //    amt_bomb_scale.SetBool("scaleup", false);
        //}
        // Debug.Log("Mesh renderer dissabled " + gameObject.name);
    }

    public void Chopped() // Called by Sword
    {
        Debug.Log("Chopped called");

        if (type == FruitType.fire || 
            type == FruitType.freeze) {
            Level_3_ScoreManager.instance.AddSpecialFruitScore();
            throwHalfFoods();
            Disable();

            StopGeneralParticle();// Must stop fire or freeze particle with the furit
        } else if (     type == FruitType.normal || 
                        type == FruitType.Double ||
                        type == FruitType.Mula ||
                        type == FruitType.Kachkola ||
                        type == FruitType.Bangi ||
                        type == FruitType.Kathal) {
            Level_3_ScoreManager.instance.AddScore();
            throwHalfFoods();
            if (Level_3_GameController.Instance.OnFire) {
                PlayFireParticle();
            }
            else if (Level_3_GameController.Instance.OnFreeze) {
                PlayFreezeParicle();
            } else {
                PlayGeneralParticle(); // Show the splash particle
            }
            Disable();
        } else if (type == FruitType.bomb) {
            Level_3_ScoreManager.instance.ReduceScore(50);
            throwHalfFoods();
            PlayBombParticles();
            Level_3_AudioManager.instance.playBoom();
            Disable();
        }
    }
    
    public void throwHalfFoods()
    {
        foreach (Level_3_FruitHalf fruithalf in allFruitHavles) {
            fruithalf.Enable();
            tr_fruit_half = fruithalf.gameObject.transform;
        }
    }

    #region Particle Contol Methods
    public void PlayGeneralParticle()
    {
        GeneralParticle.Play();
    }
    
    public void PlayFireParticle()
    {
        GeneralParticle.Play();
        Fire_Particle.Play();
    }

    public void PlayFreezeParicle()
    {
        GeneralParticle.Play();
        Freeze_Particle.Play();
    }

    void StopGeneralParticle()
    {
        GeneralParticle.Stop();
    }

    void PlayBombParticles()
    {
        BOOM_Particle.Play();
        EDGE_Particle.Play();
        // Debug.LogError("Playing bomb particles"); 
    }

    public void StopBombParticle()
    {
        BOOM_Particle.Stop();
        EDGE_Particle.Stop();
    }

    #endregion

    #region Collision and Trigger Functions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
                // Debug.Log("grounded: " + gameObject.name);
                // Debug.Break();

                if (type == FruitType.bomb)
                {
                    Invoke("Disable", 1);
                    // Debug.LogError("Bomb Invoke called from ground touch");
                }
                else
                {
                    Invoke("Disable", 1);
                }
            }
        }
    }
    #endregion
}