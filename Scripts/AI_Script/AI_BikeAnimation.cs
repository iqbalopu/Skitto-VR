using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BikeAnimation : MonoBehaviour {
    public Animator Ai_Bike_Animator;
    public void SetDirection(int direction)
    {
        Ai_Bike_Animator.SetInteger("Direction", direction);
    }

}
