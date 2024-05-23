using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{
    public GameObject prefabInstance;
    public KeyCode triggerKey = KeyCode.Space;
    public float increaseYAmount = 1.0f; 

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            if (prefabInstance != null)
            {
                Vector3 newPosition = prefabInstance.transform.position;
                newPosition.y += increaseYAmount;
                prefabInstance.transform.position = newPosition;
                float currentRotationY = prefabInstance.transform.rotation.eulerAngles.y;
                prefabInstance.transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
            }
        }
    }
}