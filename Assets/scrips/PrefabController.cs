using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{
    public GameObject prefabInstance; // La instancia del prefab en la escena
    public KeyCode triggerKey = KeyCode.Space; // La tecla que disparar� la acci�n
    public float increaseYAmount = 1.0f; // Cantidad a aumentar en Y

    void Update()
    {
        // Verificar si se ha presionado la tecla especificada
        if (Input.GetKeyDown(triggerKey))
        {
            if (prefabInstance != null)
            {
                // Aumentar la posici�n en Y
                Vector3 newPosition = prefabInstance.transform.position;
                newPosition.y += increaseYAmount;
                prefabInstance.transform.position = newPosition;

                // Obtener la rotaci�n actual en el eje X
                float currentRotationY = prefabInstance.transform.rotation.eulerAngles.y;

                // Resetear la rotaci�n manteniendo el eje X
                prefabInstance.transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
            }
        }
        else
        {
            Debug.LogWarning("Prefab instance is not assigned.");
        }
    }
}