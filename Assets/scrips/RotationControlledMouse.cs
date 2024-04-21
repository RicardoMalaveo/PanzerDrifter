using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RotationControlledMouse : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float rotationSpeed = 0.5f;

    Camera cam = null;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
       
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 mouseDirection = ray.direction;
        mouseDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(mouseDirection);
     
            Quaternion currentRotation = transform.rotation;
            float angularDifference = Quaternion.Angle(currentRotation, targetRotation);

            // will always be positive (or zero)
            if (angularDifference > 0) transform.rotation = Quaternion.Slerp(
                                         currentRotation,
                                         targetRotation,
                                         (rotationSpeed * 180 * Time.deltaTime) / angularDifference
                                    );
            else transform.rotation = targetRotation;
    }
}
