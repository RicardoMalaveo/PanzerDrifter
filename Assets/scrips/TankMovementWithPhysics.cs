using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementWithPhysics : MonoBehaviour
{
    [SerializeField] WheelCollider rightFront1;
    [SerializeField] WheelCollider rightFront2;
    [SerializeField] WheelCollider rightFront3;
    [SerializeField] WheelCollider rightBack4;
    [SerializeField] WheelCollider rightBack5;
    [SerializeField] WheelCollider rightBack6;
    [SerializeField] WheelCollider leftFront1;
    [SerializeField] WheelCollider leftFront2;
    [SerializeField] WheelCollider leftFront3;
    [SerializeField] WheelCollider leftBack4;
    [SerializeField] WheelCollider leftBack5;
    [SerializeField] WheelCollider leftBack6;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;


    public float accereletion = 500.0f;
    public float brakeForce = 400.0f;
    public float rotationSpeed = 100.0f;
    public float wheelRotationSpeed = 500.0f;
    private float currentAcceleration = 0.0f;
    private float currentBreakForce = 0.0f;
    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        RotateWheel(moveInput, rotationInput);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {

             RotateTank(rotationInput);
             //getforward reverse acceleration from the vertical axis

             currentAcceleration = accereletion * moveInput;


             //apply breakforce to the tank

             if (Input.GetKey(KeyCode.Space))
             {
                 currentBreakForce = brakeForce;
             }
             else
             {
                 currentBreakForce = 0.0f;
             }

             //Apply acceleration to left side wheels
             rightFront1.motorTorque = currentAcceleration;
             rightFront2.motorTorque = currentAcceleration;
             rightFront3.motorTorque = currentAcceleration;
             rightBack4.motorTorque = currentAcceleration;
             rightBack5.motorTorque = currentAcceleration;
             rightBack6.motorTorque = currentAcceleration;
             leftFront1.motorTorque = currentAcceleration;
             leftFront2.motorTorque = currentAcceleration;
             leftFront3.motorTorque = currentAcceleration;
             leftBack4.motorTorque = currentAcceleration;
             leftBack5.motorTorque = currentAcceleration;
             leftBack6.motorTorque = currentAcceleration;


             //apply breaking force to all wheels
             rightFront1.brakeTorque = currentBreakForce;
             rightFront2.brakeTorque = currentBreakForce;
             rightFront3.brakeTorque = currentBreakForce;
             rightBack4.brakeTorque = currentBreakForce;
             rightBack5.brakeTorque = currentBreakForce;
             rightBack6.brakeTorque = currentBreakForce;
             leftFront1.brakeTorque = currentBreakForce;
             leftFront2.brakeTorque = currentBreakForce;
             leftFront3.brakeTorque = currentBreakForce;
             leftBack4.brakeTorque = currentBreakForce;
             leftBack5.brakeTorque = currentBreakForce;
             leftBack6.brakeTorque = currentBreakForce;
    }
    private void RotateTank(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;

        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);

        rb.MoveRotation(rb.rotation * turnRotation);


    }
    void RotateWheel(float moveInput, float rotationInput)
    {
        float WheelRotation = moveInput * wheelRotationSpeed * Time.fixedDeltaTime;
        //move the left wheels
        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(WheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
        //move the right wheels
        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(WheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }
}
