using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControlledMouse : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float rotationSpeed = 0.5f;
    public Transform objectToFollowFree;

    Camera cam = null;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {

        }
        else
        {

           Cursor.lockState = CursorLockMode.Locked;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 mouseDirection = ray.direction;
            mouseDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(mouseDirection);

            Quaternion currentRotation = transform.rotation;
            float angularDifference = Quaternion.Angle(currentRotation, targetRotation);

            // will always be positive (or zero)
            if (angularDifference > 0) 
            {
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, (rotationSpeed * 180 * Time.deltaTime) / angularDifference);
            }  
            else 
            {
                transform.rotation = targetRotation;
            }    
        }
    }
}
