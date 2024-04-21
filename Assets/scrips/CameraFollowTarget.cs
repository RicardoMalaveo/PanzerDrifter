using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public float spinSpeed = 150.0f;
    void Update()
    {

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * spinSpeed * Time.deltaTime);
    }
}
