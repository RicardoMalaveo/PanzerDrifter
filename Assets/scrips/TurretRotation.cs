using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretRotation : MonoBehaviour
{ 
    public float VSpeed = 80F;
    public float HSpeed = 120F;


    [SerializeField] private Transform target;


    [SerializeField] private CameraAngle cameraAngle;

    private CameraRotation _cameraRotation;
    [Serializable]

    public struct CameraRotation
    {
        public float Pitch;
        public float Yaw;


    }
    [Serializable]
    public struct CameraAngle
    {
        public float min;
        public float max;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {

        }
        else
        {
            _cameraRotation.Yaw += Input.GetAxis("Mouse X") * HSpeed * Time.deltaTime;
            _cameraRotation.Pitch -= Input.GetAxis("Mouse Y") * VSpeed * Time.deltaTime;
            _cameraRotation.Pitch = Mathf.Clamp(_cameraRotation.Pitch, cameraAngle.min, cameraAngle.max);
            transform.eulerAngles = new Vector3(_cameraRotation.Pitch, _cameraRotation.Yaw, 0F);
        }
        
    }
}

