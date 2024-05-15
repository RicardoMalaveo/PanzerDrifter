using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void RestarGame()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
        
    }
    public void PlayButton()
    {
        Debug.Log("Egypt");
        SceneManager.LoadScene("Egypt");

    }
    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
