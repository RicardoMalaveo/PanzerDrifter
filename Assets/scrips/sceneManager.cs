using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void ExitToMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }

    public void PlayButton()
    {
        Time.timeScale = 1F;
        Debug.Log("Egypt");
        SceneManager.LoadScene("Egypt");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
