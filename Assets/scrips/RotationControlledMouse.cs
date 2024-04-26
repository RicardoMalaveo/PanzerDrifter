using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControlledMouse : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float rotationSpeed;
    private float negativeAngle = -0.007F;
    private float positiveAngle = 0.007F;
    public Transform tankBody;
    public Transform turretPoint;

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
            Vector3 PointToScreen = Camera.main.WorldToScreenPoint(turretPoint.position);
            float screenDiference = (PointToScreen.x - Input.mousePosition.x)/ Screen.width;

                if(screenDiference > 0) 
                {
                    if (screenDiference > positiveAngle)
                    {
                    transform.RotateAround(transform.position, tankBody.up, 7.5F * rotationSpeed * Time.deltaTime);
                    }
                    
                }

                if (screenDiference < 0) 
                {
                    if (screenDiference < negativeAngle)
                    {
                    transform.RotateAround(transform.position, tankBody.up, -7.5F * rotationSpeed * Time.deltaTime);
                    }
                   
                }
        }
    }
}
