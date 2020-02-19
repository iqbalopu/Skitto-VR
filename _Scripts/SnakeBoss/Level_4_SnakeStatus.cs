using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeStatus : MonoBehaviour {
    #region Public Variables
    [Header("_____GameObject Variables_____")]
    public GameObject skittoBot;
    public GameObject skittobotFly;
    [Header("_____Array Variables_____")]
    public GameObject[] Lights;
    [Header("____Float Variables____")]
    public float Life;
    public float MaxLife = 20;
    [Header("____Transform Variacles____")]
    public Transform JilapiHolderTransForm;
    public Transform PlayerTransform;
    public Transform DeathPosition;
    public Transform EatingPosition;
    [Header("____Animator Variables____")]
    public Animator skittoRoundAnim;
    [Header("____Particle Variables____")]
    public ParticleSystem AwesomeParticle;
    [Header("____Boolean Variables____")]
    public bool isDamaged;
    public bool isDead;
    public bool isIdle;
    #endregion
    #region Private Variables
    Level_4_SkittoAnimation skittoAnimation;
    Animator jilapiAnimator;
    BoxCollider PlayerMesh;
    Level_4_SnakeAnimation snakeAnimation;
    Level_4_SnakeMovement snakeMovement;
    Level_4_SnakeEffects snakeEffects;
    Level_4_SnakeExplosiveController snakeExplosives;
    Level_4_SnakeHealth snakeHealth;
    Level_4_SnakeAudio snakeAudio;
    #endregion
    private void Awake()
    {
        snakeAnimation = GetComponent<Level_4_SnakeAnimation>();
        snakeMovement = GetComponentInParent<Level_4_SnakeMovement>();
        snakeEffects = GetComponent<Level_4_SnakeEffects>();
        snakeExplosives = GetComponent<Level_4_SnakeExplosiveController>();
        snakeHealth = GetComponent<Level_4_SnakeHealth>();
        snakeAudio = GetComponentInParent<Level_4_SnakeAudio>();
        PlayerTransform = GameObject.FindGameObjectWithTag("PlayerController").transform;
        PlayerMesh = GetComponentInChildren<BoxCollider>();
        skittoAnimation = skittoBot.GetComponent<Level_4_SkittoAnimation>();
        jilapiAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        Life = 1;
        isDamaged = false;
        isDead = false;
        isIdle = false;
        skittobotFly.SetActive(false);
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.gameTimeOn)
        {
            if (Life < (1f / MaxLife))
            {
                ShrinkCallInvoke();
                snakeAnimation.PlayDead();
                snakeMovement.CanclePositionUpdateInvoke();
                isDead = true;
                snakeAudio.PlaySnakeDeathSound();
                Level_4_AudioController.instance.StopBG();
                Level_4_GameTimeController.instance.gameTimeOn = false;
                Level_4_GameTimeController.instance.jilapiDead = true;
                Level_4_GameController.instance.SetGameOver();
                PlayerMesh.enabled = false;
            }
        }
    }
#region _______Coroutines________
    void ShrinkCallInvoke() {
        StartCoroutine(shrinkJilapi());
    }
    IEnumerator shrinkJilapi()
    {
        foreach (GameObject g in Lights)
        {
            g.SetActive(false);
        }
        while ((Vector3.Distance(transform.position, DeathPosition.position) > .01f)
            && (Vector3.Distance(transform.localScale, DeathPosition.localScale) > .01f)
            )
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, DeathPosition.rotation, Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, DeathPosition.position, Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, DeathPosition.localScale, Time.deltaTime); // DeathPosition.localScale;
            yield return new WaitForEndOfFrame();
        }
        Invoke("SetSkittotoEatSnake_Invoke", 8f);
    }
    void EatJilapi_Invoke()
    {
        StartCoroutine(EatJilapi());
    }
    IEnumerator EatJilapi()
    {
        snakeAnimation.Play_DeathVibration();
        transform.rotation = DeathPosition.rotation;
        while ((Vector3.Distance(transform.position, EatingPosition.position) > .01f)
            && (Vector3.Distance(transform.localScale, EatingPosition.localScale) > .01f)
            )
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, EatingPosition.rotation, Time.deltaTime * 10);
            transform.position = Vector3.Lerp(transform.position, EatingPosition.position, Time.deltaTime * 10);
            transform.localScale = Vector3.Lerp(transform.localScale, EatingPosition.localScale, Time.deltaTime * 10); // DeathPosition.localScale;
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion
#region ________Private Methods__________
    void Set_skittoBotFly_Invoke()
    {
        skittobotFly.SetActive(true);
        Level_4_AudioController.instance.PlayCoiling();
        skittoRoundAnim.SetBool("Rotate", true);
    }
    void SetExplosion_Invoke()
    {
        AwesomeParticle.Play();
        Level_4_AudioController.instance.PlayPoof();
        skittoRoundAnim.SetBool("Rotate", false);
        skittobotFly.SetActive(false);
        Invoke("SkittoFistBump_Invoke", 1f);
    }
    void SkittoFistBump_Invoke()
    {
        Level_4_GameTimeController.instance.fistBump = true;
    }
#endregion
    #region ________Public Methods_________
    public void GettingDamage()
    {
        Life -= (1f/MaxLife);
        snakeAudio.PlaySnakeHurtSound();
        snakeHealth.DecreaseHelthText();
        snakeHealth.PlayAppear();
        isDamaged = true;
        snakeEffects.PlayHurtParticle();
        Invoke("StartMoving_Invoke", 1);
        snakeAnimation.PlayDamage();
    }
    public void StartMoving_Invoke()
    {
        isDamaged = false;
    }
    public void ThrowExplosive()
    {
        if(Level_4_GameTimeController.instance.gameTimeOn)
        {
            if (!isDamaged)
            {
                snakeEffects.PlayAttackParticle();
                snakeExplosives.ThroExplosiveAtPlayer();
            }
            else
            {
                //Debug.Log("Cant throw explosive");
            }
        }
    }
    public void SetSkittotoEatSnake_Invoke()
    {
        Level_4_GameTimeController.instance.eatSnake = true;
        Invoke("Set_skittoBotFly_Invoke", 1f);
        Invoke("EatJilapi_Invoke", 4f);
        Invoke("SetExplosion_Invoke", 4f);
    }
    public void PlayHitGroundSound()
    {
        snakeAudio.PlayJilapiHitGroundAudio();
    }
#endregion
}
