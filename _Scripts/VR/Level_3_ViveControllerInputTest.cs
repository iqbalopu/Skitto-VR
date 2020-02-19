using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_ViveControllerInputTest : MonoBehaviour {

    // https://www.raywenderlich.com/149239/htc-vive-tutorial-unity

    public Animator SwordAnimator;
    public bool isLeft;

    // remove those fields
    // public bool TestIsTriggerPressed = false;

    private void OnEnable()
    {

        // Invoke("presstrigger", 5f);

    }

    private void Start()
    {
        if (name == "Controller (left)")
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
    }

    public void presstrigger()
    {
        // TestIsTriggerPressed = true;
        Debug.Log("Trigger pressed value set");
    }

    private SteamVR_TrackedObject trackedObj;
    // 2
	// Update is called once per frame
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

	void Update () {
        // Debug.Log("Update Calling, trigger press is: " + TestIsTriggerPressed);

        // 2
        if (/*TestIsTriggerPressed || */Controller.GetHairTriggerDown())
        {
            Debug.LogError(gameObject.name + " TTTTTrigger Press");
            //rumbleController();
            //GameController.Instance.FreezeTimeScale();
            SwordAnimator.SetBool("Open", true);
            Level_3_AudioManager.instance.PlayLightSaberStart(isLeft);
        }

        // 1
        if (Controller.GetAxis() != Vector2.zero)
        {
            // Debug.Log(gameObject.name + Controller.GetAxis());
        }
        
        // 3
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
            //GameController.Instance.ResetTimeScale();
        }

        // 4
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
            
        }
        
        // 5
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    public void rumbleController()
    {
        StartCoroutine(LongVibration(.05f, 3999));
    }
    IEnumerator LongVibration(float length, float strength)
    {
        for (float i = 0; i < length; i += Time.deltaTime)
        {
            Controller.TriggerHapticPulse((ushort)Mathf.Lerp(0, 1500, 1500));
            yield return null;
        }
    }
}
