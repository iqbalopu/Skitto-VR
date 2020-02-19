using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_FruitHalf : MonoBehaviour {

    public enum FruitHalfType { Left,Right}
    FruitHalfType thisHalf;
    public bool isUpperHalf;

    #region Component
    public Rigidbody thisRigidbody;
    public BoxCollider boxCollider;
    public Transform thisTransform;
    public MeshRenderer meshRenderer;
    #endregion

    private void Awake()
    {
        thisTransform   = GetComponent<Transform>();
        thisRigidbody   = GetComponent<Rigidbody>();
        boxCollider     = GetComponent<BoxCollider>();
        meshRenderer    = GetComponent<MeshRenderer>();

        if (gameObject.name == "Left")
        {
            thisHalf = FruitHalfType.Left;
        }
        else
        {
            thisHalf = FruitHalfType.Right;
        }
    }

    private void Start()
    {
        Disable();
    }

    void Disable()
    {
        meshRenderer.enabled = false;
        boxCollider.enabled   = false;
        thisRigidbody.isKinematic = true;
    }

    public void Enable()
    {
        boxCollider.enabled = true;
        thisRigidbody.isKinematic = false;
        meshRenderer.enabled = true;
        
        // Reset to parents position
        thisTransform.position = transform.parent.position;
        thisTransform.rotation = transform.parent.rotation;
        AddRandomForce();
    }

    public void AddRandomForce()
    {
        // GetComponent < Rigidbody > ().AddForce(-.50f * UnityEngine.Random.Range(1, 40), .50f * UnityEngine.Random.Range(1, 40), 0);
        // Debug.Log("Im a child of " + gameObject.transform.parent.gameObject.name);
        if (thisHalf == FruitHalfType.Left)
        {
            thisRigidbody.AddForce(Vector3.left * UnityEngine.Random.Range(50, 70));
        }
        else if(thisHalf == FruitHalfType.Right)
        {
            thisRigidbody.AddForce(Vector3.right * UnityEngine.Random.Range(50, 70));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Invoke("Disable", 1);
        }
    }
}