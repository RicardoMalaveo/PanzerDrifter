using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapManager : MonoBehaviour
{
    public List<checkPointManager> checkpoints;
    public int totalLaps;

    private void OnTriggerEnter(Collider collision)
    {

            checkPointAndPointSystem CheckPointManager = FindAnyObjectByType<checkPointAndPointSystem>();
            if (CheckPointManager.checkPointIndex == checkpoints.Count)
            {
            CheckPointManager.checkPointIndex = 0;
            CheckPointManager.lapNumber++;
            }

            if (CheckPointManager.lapNumber >= totalLaps)
            {
                Debug.Log("victory!");
            }
    }
}
