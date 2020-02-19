using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour {

    
    public float NitroValue=1;
    Rigidbody rigidbody;
    public Handlebar_InputCalculator handlebar;
    public BikeAudioController bikeAudioController;
    public BikeCollision bikeCollision;
    public Bike_Effect bikeEffect;
    public float speed;
    public float TopSpeed;
    public float Throttle;
    public bool NitroEnabled;

    private void Awake()
    {
        handlebar = GetComponent<Handlebar_InputCalculator>();
        rigidbody = GetComponent<Rigidbody>();
        bikeAudioController = GetComponent<BikeAudioController>();
        bikeEffect = GetComponent<Bike_Effect>();
        bikeCollision = GetComponent<BikeCollision>();
        NitroEnabled = false;
    }
    public float editorX;
    public float eulerX;

	void Update () {

        //eulerX = transform.eulerAngles.x;
        //if (transform.eulerAngles.x > 180)
        //{
        //    editorX = (transform.eulerAngles.x-360);
        //}
        //else
        //{
        //    editorX = transform.eulerAngles.x;
        //}
        //if (editorX > 25)
        //{
        //    transform.eulerAngles = new Vector3(25, 0, 0);
        //}
        //if (editorX < -25)
        //{
        //    transform.eulerAngles = new Vector3(-25, 0, 0);
        //}
        
        if (GameController.instance.RaceStart && !GameController.instance.GameOver)
        {

            Throttle = handlebar.Vertical;
            if (reduceSpeedForObstacle)
            {
                Throttle = 0;
            }
            float target = Throttle * TopSpeed;
            if (handlebar.BrakePressed)
            {
                speed = Mathf.Lerp(speed, 0, Time.deltaTime);
            }
            else
            {
                speed = Mathf.Lerp(speed, target, Time.deltaTime);
            }
            if (handlebar.NitroPressed)
            {
                NitroValue -= Time.deltaTime/10;
                if (NitroValue > .01f)
                {
                    bikeEffect.SetNitro(true);
                    speed = Mathf.Lerp(speed, target * 3, Time.deltaTime);
                }
            }
            else
            {
                NitroValue += Time.deltaTime*10;
                bikeEffect.SetNitro(false);
            }
            
            NitroValue = Mathf.Clamp(NitroValue, 0, 1);
            bikeEffect.SetNitro(NitroValue);

            

            if (GameController.instance.isDead)
            {
                Time.timeScale -= Time.deltaTime / 10;
                if (Time.timeScale <= 0)
                {
                    Time.timeScale = 0;
                }
            }

            //transform.Translate(Vector3.forward *Time.deltaTime*speed);
            transform.Translate(Vector3.right  * handlebar.Horizontal * .1f);
            Vector3 velocity = Vector3.forward * speed;
            if (!bikeCollision.isGrounded)
            {
                velocity.y = -500 * Time.deltaTime;
            }
            else
            {
                velocity.y = rigidbody.velocity.y;//
            }

            if (transform.position.y < -50)
            {
                transform.position = new Vector3(0, 100, transform.position.z);
            }
            //velocity.y = rigidbody.velocity.y;//
            rigidbody.velocity = velocity;
        }
        else
        {
            //Debug.Log("Gameover: " + GameController.instance.GameOver);
            speed = Mathf.Lerp(speed, 0, Time.deltaTime);
            
            Vector3 velocity = Vector3.forward * speed;
            velocity.y = rigidbody.velocity.y;//

            rigidbody.velocity = velocity;
        }
        bikeEffect.SetSpeedoMeter(speed);
    }
    bool reduceSpeedForObstacle = false;
    public void ReduceSpeed()
    {
        reduceSpeedForObstacle = true;
        bikeAudioController.PlayHaltBrake();
        StartCoroutine(speedReduction());

        //if (getSpeedRatio() > .5f)
        //{
        //    //GameController.instance.SetDead();
        //}
        //else
        //{
        //    reduceSpeedForObstacle = true;
        //    bikeAudioController.PlayHaltBrake();
        //    StartCoroutine(speedReduction());
        //}
        
    }
    IEnumerator speedReduction()
    {
        for (float s = speed; s > 0; s -= Time.deltaTime*50)
        {
            yield return new WaitForEndOfFrame();
        }
        reduceSpeedForObstacle = false;
    }

    public float getSpeedRatio()
    {
        return speed / TopSpeed;
    }
 
    public void RefillNitro() // Called from BikeTrigger
    {
        NitroValue += 1f;
        bikeAudioController.PlayNitroRefill();
    }
   
    
}
