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
                    transform.RotateAround(transform.position, tankBody.up, 10F * rotationSpeed * Time.deltaTime);
                    }
                    
                }

                if (screenDiference < 0) 
                {
                    if (screenDiference < negativeAngle)
                    {
                    transform.RotateAround(transform.position, tankBody.up, -10F * rotationSpeed * Time.deltaTime);
                    }
                   
                }



            /* if (screenDiference < rotationSpeed) 
             {
                 transform.RotateAround(transform.position, tankBody.up, screenDiference * rotationSpeed * Time.deltaTime);
             }*/

           /* Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 mouseDirection = ray.direction;
            mouseDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(mouseDirection);

            Quaternion currentRotation = transform.rotation;
            float angularDifference = Quaternion.Angle(currentRotation, targetRotation);

            // will always be positive (or zero)
            if (angularDifference > 0) 
            {
                if(Input.mousePosition.x< Screen.width/2)
                { 
                    angularDifference = -angularDifference;
                }
            }  
            else 
            {
                //transform.rotation = targetRotation;
            }
            //Quaternion.Slerp(currentRotation, targetRotation, (rotationSpeed * 180 * Time.deltaTime) / angularDifference);*/
        }
    }
}
