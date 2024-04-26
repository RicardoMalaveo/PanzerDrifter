using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonRotation : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float rotationSpeed;
    public Transform cannon;
    public Transform Tankbody;
    private float negativeAngle = -0.007F;
    private float positiveAngle = 0.007F;

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
        }
        if (screenDiference < 0)
        {
            if (screenDiference < negativeAngle)
            {
                transform.RotateAround(transform.position, Tankbody.right, -5F * rotationSpeed * Time.deltaTime);
            }    
        }
    }
}

