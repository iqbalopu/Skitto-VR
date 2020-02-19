using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_PlayerExplosive : MonoBehaviour {

    Vector3 StartPosition;
    Vector3 StarRotation;
    private void Start()
    {
        //StartPosition = transform.position;
        //StarRotation = transform.eulerAngles;
    }
    // Use this for initialization
    private void OnEnable()
    {
        Invoke("Destroy", 2f);
    }
    void Destroy()
    {
        gameObject.SetActive(false);
        //transform.position = StartPosition;
        //transform.eulerAngles = StarRotation;

    }
    private void OnDisable()
    {
        CancelInvoke();
    }
        
}
