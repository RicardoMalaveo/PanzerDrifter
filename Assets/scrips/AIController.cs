using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private AIInputManager AIM;
    public WheelCollider[] wheels = new WheelCollider[8];
    public float torque = 1000F;
    public float brakeForce = 400.0f;
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
        RotateWheel(AIM.vertical, AIM.horizontal);
        Acceleration();
        RotateTank();
        Breaks();
    }

    public void Acceleration()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = AIM.vertical * torque;
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
        rotationInput = AIM.horizontal;

        float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;

        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }
    void RotateWheel(float moveInput, float rotationInput)
    {
        float WheelRotation = AIM.horizontal * wheelRotationSpeed * Time.fixedDeltaTime;
        //move the left wheels
        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(WheelRotation - AIM.horizontal * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
        //move the right wheels
        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(WheelRotation + AIM.horizontal * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }

    private void getIM()
    {
        AIM = GetComponent<AIInputManager>();
    }


}
