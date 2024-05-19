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
        Debug.Log("Egypt");
        SceneManager.LoadScene("Egypt");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
