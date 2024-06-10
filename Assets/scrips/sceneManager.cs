using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Egypt");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
