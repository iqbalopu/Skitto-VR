using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_BatMovement : MonoBehaviour {
    Transform Player;
    Transform thisTransform;
    Level_4_BatEffects batEffects;
    public float speed=5f;
    public bool canMove;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        thisTransform = GetComponent<Transform>();
        batEffects = GetComponent<Level_4_BatEffects>();
        canMove = true;
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.gameTimeOn)
        {
            if (canMove)
            {
                thisTransform.position = Vector3.MoveTowards(thisTransform.position, Player.position, Time.deltaTime * speed);
                Vector3 lookAtVector = Player.position;
                lookAtVector.y = 0;
                thisTransform.LookAt(lookAtVector);
            }
            
        }
        else
        {
            
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            foreach (Transform t in this.transform)
            {
                t.GetComponent<Renderer>().enabled = false;
            }
            Invoke("DestroyBatObject_Invoke", 1.5f);
        }
    }
    public void StopMovement()
    {
        canMove = false;
    }
    void DestroyBatObject_Invoke()
    {
        Destroy(this.gameObject);
    }
}
