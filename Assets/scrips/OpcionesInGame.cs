using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesInGame : MonoBehaviour
{
    public GameObject options;
    public bool gamePaused = false;

    void Start()
    {
        if (options == null)
        {
            Debug.LogError("El objeto 'options' no está asignado en el Inspector.");
        }
        else
        {
            Debug.Log("El objeto 'options' se ha asignado correctamente.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Tecla 'Esc' pulsada.");
            ToggleObject();
            PauseGame();
        }
    }

    void ToggleObject()
    {
        if (options != null)
        {
            bool isActive = options.activeSelf;
            options.SetActive(!isActive);
            Debug.Log("El objeto 'options' ahora está " + (isActive ? "desactivado" : "activado") + ".");
        }
        else
        {
            Debug.LogWarning("No se ha asignado un objeto para activar/desactivar.");
        }
    }
    void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
        }
        else
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
        
    }
}
