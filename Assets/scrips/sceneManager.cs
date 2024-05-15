using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
   [SerializeField] private string sceneLoad = "Menu";
    public void RestarGame()
    {
        Debug.Log(sceneLoad);
        SceneManager.LoadScene(sceneLoad);
        
    }

}
