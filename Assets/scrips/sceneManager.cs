using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
   [SerializeField] private string raceTrack = "Egypt";
    public void RestarGame()
    {
        SceneManager.LoadScene(raceTrack);
    }

}
