using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretRotation : MonoBehaviour
{ 
    public float spinSpeed = 200F;
    float xRotation = 0F;
    public Transform tankCam;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
                
        }
        else
        {
           
            float mouseX = Input.GetAxis("Mouse X") * spinSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * spinSpeed * Time.deltaTime;
            tankCam.Rotate(Vector3.right * xRotation);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -7F, 7F);
            transform.localRotation = Quaternion.Euler(0F, mouseX, 0F);



            //transform.localRotation= Quaternion.Euler(xRotation, mouseX, 0F);
            //transform.Rotate(Vector3.right * mouseY);

            //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * spinSpeed * Time.deltaTime);

        }

    }


}

