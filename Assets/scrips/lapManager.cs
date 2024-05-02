using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapManager : MonoBehaviour
{
    public List<checkPointManager> checkpoints;
    public int totalLaps;

    private void OnTriggerEnter(Collider other)
    {
        checkPointAndPointSystem CheckPointManager = FindAnyObjectByType<checkPointAndPointSystem>();
        if (other.tag == "Player")
        {
            if (CheckPointManager.playerLapNumber >= totalLaps)
            {
                if(CheckPointManager.playerCheckPointIndex < checkpoints.Count)
                {
                    Debug.Log("AI won");
                }
                else
                {
                    Debug.Log("victory");
                }

            }
            else if (CheckPointManager.playerCheckPointIndex == checkpoints.Count)
            {
                CheckPointManager.playerCheckPointIndex = 0;
                CheckPointManager.playerLapNumber++;
            }

        }


        if (other.tag == "AITBody")
        {
            if (CheckPointManager.AILapNumber >= totalLaps)
            {
                Debug.Log("AI won");
            }
            else if (CheckPointManager.AICheckPointIndex == checkpoints.Count)
            {
                CheckPointManager.AICheckPointIndex = 0;
                CheckPointManager.AILapNumber++;
            }
        }
    }
}
