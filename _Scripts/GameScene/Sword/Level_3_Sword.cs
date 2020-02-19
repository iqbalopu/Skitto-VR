using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Sword : MonoBehaviour {

    // public GameObject go_hammer;

    public bool isLeftSword;
    Level_3_ViveControllerInputTest controller;

    public Vector3 vtr_lastVisited_pos;
    public Transform go_sword_head;
    public bool isCuttingPermitted;

    [Header("Effect Variables")]
    //public Animator FireParticle;
    //public Animator FreezeObject;

    public static Level_3_Sword Instance;

    // Use this for initialization
    void Start ()
    {
        Instance = this;
        vtr_lastVisited_pos = go_sword_head.position;
        // go_sword_head = gameObject.transform.GetChild(0).transform;
        if (name == "swordLaser_left")
        {
            isLeftSword = true;
        }
        else
        {
            isLeftSword = false;
        }
    }

    private void Awake()
    {
        controller = GetComponentInParent<Level_3_ViveControllerInputTest>();
    }

    // Update is called once per frame
    void Update () {
        float ft_velocity = (vtr_lastVisited_pos - go_sword_head.position).magnitude / Time.deltaTime;

        // Give sword permission to cut or not
        isCuttingPermitted = (ft_velocity > 15f) ? true : false;
        vtr_lastVisited_pos = go_sword_head.position;

        // wwww cutting is permitted, for test 
        // isCuttingPermitted = true;
        // Debug.Log("Velocity of" + name + " " + ft_velocity);
        if (isLeftSword)
        {
            Level_3_AudioManager.instance.Set_LigthSaberLeft(ft_velocity);
        }
        else
        {
            Level_3_AudioManager.instance.Set_LightSaberRight(ft_velocity);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log("Working!! " + other.gameObject.name); 
        if (other.gameObject.CompareTag("Fruit") && isCuttingPermitted)
        {
            controller.rumbleController();
            
            // Debug.Log("tr_other.gameObject.transform.childCount();" + other.gameObject.transform.childCount);
            Level_3_Fruit f = other.gameObject.GetComponent<Level_3_Fruit>();

            switch (f.type)
            {
                case Level_3_Fruit.FruitType.Mula:
                    {
                        Level_3_UIController.Instance.SetOfferErMula(other.transform.position);
                    }
                    break;
                case Level_3_Fruit.FruitType.Bangi:
                    {
                        Level_3_UIController.Instance.SetSorterBangi(other.transform.position);
                    }
                    break;
                case Level_3_Fruit.FruitType.Kachkola:
                    {
                        Level_3_UIController.Instance.SetSMSerKachKola(other.transform.position);
                    }
                    break;
                case Level_3_Fruit.FruitType.Kathal:
                    {
                        Level_3_UIController.Instance.SetCostErKathal(other.transform.position);
                    }
                    break;
                default:
                    break;
            }

            Level_3_AudioManager.instance.playChops();

            // chop it if not fallen onto the ground
            if (!f.isGrounded)
            {
                f.Chopped();
            }
        }
    }
}