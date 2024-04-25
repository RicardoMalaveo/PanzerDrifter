using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonRotation : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float rotationSpeed;
    private float negativeAngle = -0.003F;
    private float positiveAngle = 0.003F;
    public Transform tankBody;
    public Transform canonPoint;
    void Update()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Vector3 PointToScreen = Camera.main.WorldToScreenPoint(canonPoint.position);
        float screenDiference = (PointToScreen.y - Input.mousePosition.y) / Screen.height;

        if (screenDiference > 0)
        {
            if (screenDiference > positiveAngle)
            {
                transform.RotateAround(transform.position, tankBody.right, -5F * rotationSpeed * Time.deltaTime);
            }

        }

        if (screenDiference < 0)
        {
            if (screenDiference < negativeAngle)
            {
                transform.RotateAround(transform.position, tankBody.right, 5F * rotationSpeed * Time.deltaTime);
            }

        }
    }
}
