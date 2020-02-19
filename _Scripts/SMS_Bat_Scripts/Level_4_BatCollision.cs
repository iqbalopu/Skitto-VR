using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_BatCollision : MonoBehaviour {

    public GameObject batSpawnControllerHolder;
    Level_4_BatSpawnController batSpawnController;
    Level_4_BatEffects batEffects;
    Level_4_BatAudio batAudio;
    Level_4_BatMovement batMovement;
    public GameObject controllerLeft;
    private SteamVR_TrackedObject trackedObj;

    public MeshRenderer BatMeshRenderer, Wing1MeshRenderer, Wing2MeshRenderer;
    private void Awake()
    {
        //batSpawnController = batSpawnControllerHolder.GetComponent<Level_4_BatSpawnController>();
        batSpawnControllerHolder = GameObject.FindGameObjectWithTag("BatController");
        batSpawnController = batSpawnControllerHolder.GetComponent<Level_4_BatSpawnController>();
        batEffects = GetComponent<Level_4_BatEffects>();
        batAudio = GetComponent<Level_4_BatAudio>();
        controllerLeft = GameObject.FindGameObjectWithTag("LeftController");
        batMovement = GetComponent<Level_4_BatMovement>();
        trackedObj = controllerLeft.GetComponent<SteamVR_TrackedObject>();
        BatMeshRenderer = GetComponent<MeshRenderer>();
        Wing1MeshRenderer =  transform.Find("Wing1").GetComponent<MeshRenderer>();
        Wing2MeshRenderer = transform.Find("Wing2").GetComponent<MeshRenderer>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("Bullet"))
        {
            // Debug.Log("PLayer found");
            ShowDeath();
        }
        if (other.CompareTag("Shield"))
        {
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(1000);
        }
    }

    void ShowDeath()
    {
        
        GetComponent<Collider>().enabled = false;
        BatMeshRenderer.enabled = false;
        Wing1MeshRenderer.enabled = false;
        Wing2MeshRenderer.enabled = false;
        //Damage Player
        //Dicrement CurrentbatCount
        batSpawnController.CurrentBatCount--;
        //Destroy Prefab
        batEffects.PlayBatDestroyParticle();
        batAudio.PlayBatDeadSound();
        batMovement.StopMovement();
        Invoke("DestroyBat_Invoke", 1.5f);
    }

    void DestroyBat_Invoke()
    {
        //Debug.Log("Gameobject Destroyed with name: " + this.gameObject.name);
        Destroy(this.gameObject);
    }
}
