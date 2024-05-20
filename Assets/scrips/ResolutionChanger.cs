using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class ResolutionChanger : MonoBehaviour
{
    public bool windowedMode = true;

    // M�todo para cambiar el modo de pantalla completa
    public void ToggleWindowedMode()
    {
        windowedMode = !windowedMode;
        // Obt�n la resoluci�n actual y vuelve a aplicar la configuraci�n
        int currentWidth = Screen.currentResolution.width;
        int currentHeight = Screen.currentResolution.height;
        SetResolution(currentWidth, currentHeight);
    }

    // M�todo para manejar la selecci�n del Dropdown
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

    // M�todo para establecer la resoluci�n
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