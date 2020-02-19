using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_PlayerHandShower : MonoBehaviour {

    public Transform LeftHand, RightHand;
    public Transform Gun, Shild;
    private void Start()
    {
        HideHands();
    }
    public void ShowHands()
    {
        //LeftHand.gameObject.SetActive(true);
        RightHand.gameObject.SetActive(true);

        Gun.gameObject.SetActive(false);
        Shild.gameObject.SetActive(false);
    }
    public void HideHands()
    {
        LeftHand.gameObject.SetActive(false);
        RightHand.gameObject.SetActive(false);

        Gun.gameObject.SetActive(true);
        Shild.gameObject.SetActive(true);
    }

   
}
