using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeColliderTrigger : MonoBehaviour {

    public Animator GameOverDisplay;
    public BikeMovement bikeMovement;
    private void Awake()
    {
        bikeMovement = GetComponent<BikeMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NitroTrigger"))
        {
            bikeMovement.RefillNitro();
            other.enabled = false;
        }
        if (other.CompareTag("EndTrigger"))
        {
            GameController.instance.SetGameOver();
            Invoke("GoToFruitNinjaLevel", 5);
            Debug.Log("Gameover");
            GameOverDisplay.SetTrigger("Appear");
        }
        if (other.CompareTag("ShortoCarTrigger"))
        {
            other.GetComponentInParent<ShortoCarMovement>().Set_StartMoving();
        }
    }

    void GoToFruitNinjaLevel()
    {
        LevelChangeController.instance.LoadNextLevel(3);
    }
}
