using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHolder : MonoBehaviour {

    public List<Transform> All_WP;
	// Use this for initialization
	void Awake () {
        All_WP = new List<Transform>();
        foreach (Transform t in transform)
        {
            All_WP.Add(t);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
