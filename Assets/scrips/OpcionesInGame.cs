using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesInGame : MonoBehaviour
{
    public GameObject options;
    public bool gamePaused = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            options.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            gamePaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            options.SetActive(false);
        }
    }
}
