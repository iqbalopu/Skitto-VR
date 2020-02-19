using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_PlayerCollision : MonoBehaviour {
    Level_4_PlayerHealth playerHealth;
    public GameObject playerShield;
    public GameObject Player;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("SnakeExplosive"))
        {
            Debug.Log("__________Player collided with snakeExplosive_________");
            Player.GetComponent<Level_4_PlayerHealth>().GetDamaged();
            Destroy(collision.gameObject);
            //playerShield.GetComponent<Level_4_PlayerShield>().ShowHealthBar();
        }
    }
   
}
