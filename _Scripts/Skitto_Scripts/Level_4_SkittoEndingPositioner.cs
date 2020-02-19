using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SkittoEndingPositioner : MonoBehaviour {

    bool hasCalculated;
    public Transform CameraPosition;
    public float distanceZ;
    public float distanceY;
    private void Start()
    {
        hasCalculated = false;
    }
    public void CalCulatePositin()
    {
        if (!hasCalculated)
        {
            transform.position = new Vector3(CameraPosition.position.x, CameraPosition.position.y + distanceY, CameraPosition.position.z + distanceZ);
            hasCalculated = true;
        }
        
    }
    

}
