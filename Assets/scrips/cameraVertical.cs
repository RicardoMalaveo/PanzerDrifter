using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraVertical : MonoBehaviour
{
    public GameObject camerasParent;
    public float hRotationSpeed = 100f;
    public float vRotationSpeed = 80f;
    public float maxVerticalAngel;
    public float minVerticalAngle;
    public float smoothTime = 0.05f;

    float vCamRotationAngles;
    float hPlayerRotation;
    float currentHVelocity;
    float currentVVelocity;
    float targetCamEulers;
    Vector3 targetCmRotation;


    public void handleRotation(float hInput, float vInput)
    {
        float targetPlayerRotation = hInput * hRotationSpeed * Time.deltaTime;
        targetCamEulers += vInput * vRotationSpeed * Time.deltaTime;

        hPlayerRotation = Mathf.SmoothDamp(hPlayerRotation, targetPlayerRotation, ref currentHVelocity, smoothTime);
        transform.Rotate(0f, hPlayerRotation, 0f);

        targetCamEulers = Mathf.Clamp(targetCamEulers, minVerticalAngle, maxVerticalAngel);
        vCamRotationAngles = Mathf.SmoothDamp(vCamRotationAngles, targetCamEulers, ref currentVVelocity, smoothTime);
        targetCmRotation.Set(-vCamRotationAngles, 0f, 0f);
        camerasParent.transform.localEulerAngles = targetCmRotation;
    }
}
