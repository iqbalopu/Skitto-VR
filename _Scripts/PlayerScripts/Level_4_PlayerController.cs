using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_PlayerController : MonoBehaviour {
    #region _____Public Variables_____
    [Header("_____GameObject Variables_____")]
    public GameObject controllerRight;
    public GameObject bullet;
    public GameObject playergun, playerShield;
    [Header("_____Transform Variables_____")]
    public Transform muzzel;
    [Header("_____Float Variables_____")]
    public float thrustSpeed;
    [Header("_____Integer Variables_____")]
    public int bulletCount = 20;
    [Header("_____AudioSource Variables_____")]
    public AudioSource GunAudioSource;
    [Header("_____Array Variables_____")]
    public Color[] BulletColors;
    [Header("_____Particle Variables_____")]
    public ParticleSystem muzzelFlash;
    #endregion
    #region ______Private Variables______
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private SteamVR_TrackedController controller;
    List<GameObject> bullets;
    GameObject Player;
    int colorCount = 0;
    #endregion
#region ________Private Methods_______
    private void Awake()
    {
        bullets = new List<GameObject>();
        Player = GameObject.FindGameObjectWithTag("Player");
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
    }
    void Start()
    {
        controller.TriggerClicked += TriggerPressed;
        for(int i=0;i<bulletCount;i++)
        {
            GameObject obj = InstantiateBullet();
            obj.transform.Rotate(Vector3.left * 90);
            obj.GetComponent<Renderer>().material.SetColor("_Color", BulletColors[colorCount]);
            obj.GetComponent<Renderer>().material.SetColor("_SpecColor", BulletColors[colorCount]);
            obj.GetComponent<Renderer>().material.SetColor("_Emission", BulletColors[colorCount]);
            colorCount = (colorCount + 1) % BulletColors.Length;
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }
    private void TriggerPressed(object sender, ClickedEventArgs e)
    {
        Debug.LogWarning("Object Sender name: " + sender);
        Debug.LogWarning("Click Event Arguments: " + e);
        Shoot();
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.gameOver)
        {
            playergun.SetActive(false);
            playerShield.SetActive(false);
        }
    }
    GameObject InstantiateBullet()
    {
        return Instantiate(bullet, muzzel.position, Quaternion.identity);
    }
    void Shoot()
    {
        if(Level_4_GameTimeController.instance.gameTimeOn)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets[i].SetActive(true);
                    ShootWithForce(bullets[i]);
                    break;
                }
            }
        }
    }
    void ShootWithForce(GameObject obj)
    {
        obj.transform.position = muzzel.position;
        obj.transform.eulerAngles = muzzel.eulerAngles;
        GunAudioSource.Play();
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = obj.transform.forward * thrustSpeed;
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(1000);
    }
#endregion
}
