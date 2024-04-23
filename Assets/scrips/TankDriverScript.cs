using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankDriverScript : MonoBehaviour
{
    private inputManager IM;
    public WheelCollider[] wheels = new WheelCollider[8];
    public float torque = 550000F;
    public float brakeForce = 1000000000000f;
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

    private void FixedUpdate()
    {
        RotateWheel();
        Acceleration();
        RotateTank();
        Breaks();
    }

    public void Acceleration()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = IM.vertical * torque;
        }
    }

    public void Breaks()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = brakeForce;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 0F;
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
