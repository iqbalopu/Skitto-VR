using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bike : MonoBehaviour {
    public Transform WaypointObject;
    private void Update()
    {
        Vector3 targePosition = new Vector3(WaypointObject.position.x, transform.position.y, WaypointObject.position.z);
        transform.position = Vector3.Lerp(transform.position, targePosition, Time.deltaTime);
    }
}
