using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TankDriverScript : MonoBehaviour
{
    public RawImage engine;
    public RawImage leftOruga;
    public RawImage rightOruga;
    private inputManager IM;
    public WheelCollider[] wheelsRight = new WheelCollider[4]; 
    public WheelCollider[] wheelsLeft = new WheelCollider[4];
    public float torqueRight = 550000F;
    public float torqueLeft = 550000F;
    public float torqueMaxRight = 550000F;
    public float torqueMaxLeft = 550000F;
    private float brakeForce = 1000000000000f;
    public float rotationSpeed = 100.0f;
    private Rigidbody rb;
    private float rotationInput;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;
    public float wheelRotationSpeed = 500.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        getIM();
    }

    void Update()
    {
        if(torqueRight >440000F)
        {
            rightOruga.color = Color.green;
        }
        else if(torqueRight>330000)
        {
            rightOruga.color = Color.yellow;
        }
        else if (torqueRight > 220000)
        {
            rightOruga.color = Color.red;
        }
        else
        {
            rightOruga.color = Color.black;
        }

        if (torqueLeft > 440000F)
        {
            leftOruga.color = Color.green;
        }
        else if (torqueLeft > 330000)
        {
            leftOruga.color = Color.yellow;
        }
        else if (torqueLeft > 220000)
        {
            leftOruga.color = Color.red;
        }
        else
        {
            leftOruga.color = Color.black;
        }


        if (torqueLeft > 440000F && torqueRight > 440000F)
        {
            engine.color = Color.green;
        }
        else if (torqueLeft > 330000 && torqueRight > 330000)
        {
            engine.color = Color.yellow;
        }
        else if (torqueLeft > 220000 && torqueRight > 220000)
        {
            engine.color = Color.red;
        }
        else
        {
            engine.color = Color.black;
        }

    }

    private void FixedUpdate()
    {
        RotateWheel();
        Acceleration();
        RotateTank();
        Breaks();
    }

    public void Acceleration()
    {
        for (int i = 0; i < wheelsRight.Length; i++)
        {
            wheelsRight[i].motorTorque = IM.vertical * torqueRight;
        }

        for (int i = 0; i < wheelsLeft.Length; i++)
        {
            wheelsLeft[i].motorTorque = IM.vertical * torqueRight;
        }
    }

    public void Breaks()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < wheelsRight.Length; i++)
            {
                wheelsRight[i].brakeTorque = brakeForce;
            }
        }
        else
        {
            for (int i = 0; i < wheelsRight.Length; i++)
            {
                wheelsRight[i].brakeTorque = 0F;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < wheelsLeft.Length; i++)
            {
                wheelsLeft[i].brakeTorque = brakeForce;
            }
        }
        else
        {
            for (int i = 0; i < wheelsLeft.Length; i++)
            {
                wheelsLeft[i].brakeTorque = 0F;
            }
        }
    }

    public void RotateTank()
    {
        //tank rotation
        rotationInput = IM.horizontal;

        float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;

         Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);

         rb.MoveRotation(rb.rotation * turnRotation);
    }
    void RotateWheel()
    {
        float WheelRotation = IM.vertical * wheelRotationSpeed * Time.fixedDeltaTime;
        //move the left wheels
        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate( 0.0f, WheelRotation - IM.horizontal * wheelRotationSpeed * Time.deltaTime, 0.0f);
            }
        }
        //move the right wheels
        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(0.0f, WheelRotation + IM.horizontal * wheelRotationSpeed * Time.deltaTime, 0.0f);
            }
        }
    }

    private void getIM()
    {
        IM = GetComponent<inputManager>();
    }


}
