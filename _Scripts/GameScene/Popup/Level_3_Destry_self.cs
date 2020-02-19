using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Destry_self : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroySelf", 5f);
	}
	
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
