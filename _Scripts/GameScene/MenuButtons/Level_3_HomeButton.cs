using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_HomeButton : MonoBehaviour {

    public bool isButtonPressed = false;
    public int nt_level_to_be_loaded = 0;
    public bool isButtonEnabled = false;
    public GameObject go_stone_top, go_stone_bottom;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // anim.SetBool("Dying", true);
            // 
            StoneBreak();
        }

    }
    private void Start()
    {
        isButtonEnabled = false;
        // Enable the button after 3 seconds
        Invoke("EnableButton", 1.2f);
    }

    public void EnableButton()
    {
        isButtonEnabled = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword") && !isButtonPressed && isButtonEnabled)
        {
            isButtonPressed = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Level_3_AudioManager.instance.PlayDong();
            Invoke("LoadLevel", 1.5f);
            StoneBreak();
        }
    }

    public void StoneBreak()
    {
        go_stone_bottom.GetComponent<MeshRenderer>().enabled = true;
        go_stone_bottom.GetComponent<Rigidbody>().isKinematic = false;
        // boxCollider.enabled = true;
        go_stone_bottom.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-30, 30), Random.Range(30, 90), Random.Range(-50, 300)));

        go_stone_top.GetComponent<MeshRenderer>().enabled = true;
        go_stone_top.GetComponent<Rigidbody>().isKinematic = false;
        // boxCollider.enabled = true;
        go_stone_top.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-30, 30), Random.Range(30, 90), Random.Range(-50, 300)));
    }

    public void LoadLevel()
    {
        Debug.LogError("Sword pressed Home Button");
        Application.LoadLevel(nt_level_to_be_loaded);
    }
}