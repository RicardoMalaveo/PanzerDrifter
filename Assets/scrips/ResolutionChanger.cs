using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class ResolutionChanger : MonoBehaviour
{
    public bool windowedMode = true;

    // Método para cambiar el modo de pantalla completa
    public void ToggleWindowedMode()
    {
        windowedMode = !windowedMode;
        // Obtén la resolución actual y vuelve a aplicar la configuración
        int currentWidth = Screen.currentResolution.width;
        int currentHeight = Screen.currentResolution.height;
        SetResolution(currentWidth, currentHeight);
    }

    // Método para manejar la selección del Dropdown
    public void HandleInputData(int val)
    {
        switch (val)
        {
            case 0:
                SetResolution(1366, 768);
                break;
            case 1:
                SetResolution(1920, 1080);
                break;
            case 2:
                SetResolution(2560, 1440);
                break;
            case 3:
                SetResolution(3840, 2160);
                break;
        }
    }

    // Método para establecer la resolución
    private void SetResolution(int width, int height)
    {
        if (windowedMode)
        {
            Screen.SetResolution(width, height, FullScreenMode.Windowed);
            Debug.Log($"{width}x{height}, windowed");
        }
        else
        {
            Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
            Debug.Log($"{width}x{height}, fullscreen");
        }
    }
}