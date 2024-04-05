using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRotationAI : MonoBehaviour
{
    public float spinSpeed = 150.0f;


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {

        }
        else
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * spinSpeed * Time.deltaTime);
        }
    }

}
