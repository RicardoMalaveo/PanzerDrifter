using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControlledMouse : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float rotationSpeed;
    private float negativeAngle = -0.003F;
    private float positiveAngle = 0.003F;
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
                        transform.RotateAround(transform.position, tankBody.up, 9F * rotationSpeed * Time.deltaTime);
                    }
                    else if (screenDiference > 0.002F)
                    {
                        transform.RotateAround(transform.position, tankBody.up, 4.5F * rotationSpeed * Time.deltaTime);
                    }
                    else if (screenDiference > 0.001F)
                    {
                        transform.RotateAround(transform.position, tankBody.up, 2.5F * rotationSpeed * Time.deltaTime);
                    }
                }

                if (screenDiference < 0) 
                {
                    if (screenDiference < negativeAngle)
                    {
                    transform.RotateAround(transform.position, tankBody.up, -9F * rotationSpeed * Time.deltaTime);
                    }
                    else if (screenDiference < -0.002F)
                    {
                        transform.RotateAround(transform.position, tankBody.up, -4.5F * rotationSpeed * Time.deltaTime);
                    }
                    else if (screenDiference < -0.0015F)
                    {
                    transform.RotateAround(transform.position, tankBody.up, -2.5F * rotationSpeed * Time.deltaTime);
                    }

                }
        }
    }
}
