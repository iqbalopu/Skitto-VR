using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handlebar_InputCalculator : MonoBehaviour {
    public bool KeyboardInput;
    public SteamVR_TrackedController RightController,LeftController;
    
    public Transform RightHandleBar, LeftHandleBar;
    public float Horizontal, Vertical;
    public bool BrakePressed,NitroPressed;

    BikeAudioController bikeAudioController;

    public BikeReposition bikeReposition;
    private void Awake()
    {
        bikeAudioController = GetComponent<BikeAudioController>();
    }
    // Use this for initialization
    void Start () {
        GameController.instance.OnRaceStart += OnAnyNameWalaRaceStart;
	}

    void OnAnyNameWalaRaceStart()
    {
        //Debug.Log("Race started in input controller");
    }
	// Update is called once per frame
	void Update () {
        if (KeyboardInput)
        {
            Vertical = Input.GetAxis("Vertical");
            Horizontal = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                NitroPressed = true;
            }
            else
            {
                NitroPressed = false;
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                BrakePressed = true;
            }
            else
            {
                BrakePressed = false;
            }
        }
        else
        {
            Vertical = Mathf.Lerp(Vertical, Mathf.Clamp(RightHandleBar.rotation.z * 2, 0, 1), Time.deltaTime * 10);
            Horizontal = Mathf.Lerp(Horizontal, Mathf.Clamp((RightHandleBar.rotation.y + LeftHandleBar.rotation.y) * 2, -1, 1), Time.deltaTime * 10);
        }
        
        
	}
    private void OnEnable()
    {
        RightController.TriggerClicked += RightTriggerPressed;
        LeftController.TriggerClicked += LeftTriggerPressed;
        LeftController.TriggerUnclicked += LeftTriggerReleased;
        RightController.TriggerUnclicked += RightTriggerReleased;
    }

    private void OnDisable()
    {
        RightController.TriggerClicked -= RightTriggerPressed;
        LeftController.TriggerClicked -= LeftTriggerPressed;
    }
    private void LeftTriggerPressed(object sender, ClickedEventArgs e)
    {
        if (!GameController.instance.RaceStart)
        {
            bikeReposition.ForceReposition();
        }
        if(!GameController.instance.GameOver&& GameController.instance.RaceStart)
            NitroPressed = true;    
    }
    private void LeftTriggerReleased(object sender, ClickedEventArgs e)
    {
        if (!GameController.instance.RaceStart)
        {
            bikeReposition.ForceReposition();
        }
        //Debug.Log("Left Trigger Pressed");
        if (!GameController.instance.GameOver && GameController.instance.RaceStart)
            NitroPressed = false;
    }
    private void RightTriggerPressed(object sender, ClickedEventArgs e)
    {
        //Debug.Log("Right Trigger Pressed");
        if (!GameController.instance.GameOver && GameController.instance.RaceStart)
        {
            BrakePressed = true;
            bikeAudioController.BrakePressed();

        }

    }
    private void RightTriggerReleased(object sender, ClickedEventArgs e)
    {
        if (!GameController.instance.GameOver && GameController.instance.RaceStart)
        {
            BrakePressed = false;
        }
         
    }
}
