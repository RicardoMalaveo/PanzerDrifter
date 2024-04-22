using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretRotation : MonoBehaviour
{ 
    public float spinSpeed = 200.0f;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
                
        }
        else
        {
            
        }
        transform.Rotate(Vector3.forward, -Input.GetAxis("Mouse X") * spinSpeed * Time.deltaTime);
    }


}

