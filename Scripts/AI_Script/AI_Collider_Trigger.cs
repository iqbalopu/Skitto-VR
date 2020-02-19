using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Collider_Trigger : MonoBehaviour {
    AI_BikeMovement ai_BikeMovement;
    private void Awake()
    {
        ai_BikeMovement = GetComponent<AI_BikeMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            ai_BikeMovement.AI_Reached_End = true;
        }
    }
}
