using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointManager : MonoBehaviour
{
    public int index;

    public void OnTriggerEnter(Collider other)
    {

            checkPointAndPointSystem CheckPointManager = FindAnyObjectByType<checkPointAndPointSystem>();

            if (other.tag == "Player")
            {
              if (CheckPointManager.playerCheckPointIndex == index - 1)
               {
                    CheckPointManager.playerCheckPointIndex = index;
                    Debug.Log("first check point");
               }
            }


            if (other.tag == "AITBody")
            {
                if (CheckPointManager.AICheckPointIndex == index - 1)
                {
                    CheckPointManager.AICheckPointIndex = index;
                    Debug.Log("first check point");
                }
            }
    }
}
