using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonRotation : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float rotationSpeed;
    public Transform cannon;
    public Transform Tankbody;
    private float negativeAngle = -0.0036F;
    private float positiveAngle = 0.0036F;

    void Update()
    {
        Vector3 PointToScreen = Camera.main.WorldToScreenPoint(cannon.position);
        float screenDiference = (PointToScreen.y - Input.mousePosition.y) / Screen.height;


        if (screenDiference > 0)
        {
            if (screenDiference > positiveAngle)
            {
                transform.RotateAround(transform.position, Tankbody.right, 5F * rotationSpeed * Time.deltaTime);
            }
            else if (screenDiference > 0.0028F)
            {
                transform.RotateAround(transform.position, Tankbody.right, 2F * rotationSpeed * Time.deltaTime);
            }
            else if (screenDiference > 0.0028F)
            {
                transform.RotateAround(transform.position, Tankbody.right, 1F * rotationSpeed * Time.deltaTime);
            }
            else if (screenDiference > 0.002F)
            {
                transform.RotateAround(transform.position, Tankbody.right, 0.5F * rotationSpeed * Time.deltaTime);
            }
        }

        if (screenDiference < 0)
        {
            if (screenDiference < negativeAngle)
            {
                transform.RotateAround(transform.position, Tankbody.right, -5F * rotationSpeed * Time.deltaTime);
            }
            else if (screenDiference < -0.0028F)
            {
                transform.RotateAround(transform.position, Tankbody.right, -2F * rotationSpeed * Time.deltaTime);
            }
            else if (screenDiference < -0.0023F)
            {
                transform.RotateAround(transform.position, Tankbody.right, -1F * rotationSpeed * Time.deltaTime);
            }
            else if (screenDiference < -0.002F)
            {
                transform.RotateAround(transform.position, Tankbody.right, -0.5F * rotationSpeed * Time.deltaTime);
            }
        }
    }
}

