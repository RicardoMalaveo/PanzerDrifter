using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretRotation : MonoBehaviour
{ 
    public float spinSpeed = 200F;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {

        }
        else
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * spinSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * spinSpeed * Time.deltaTime);
        }

    }


}

