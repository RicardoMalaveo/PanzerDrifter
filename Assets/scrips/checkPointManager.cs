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
              if (CheckPointManager.checkPointIndex == index - 1)
               {
                CheckPointManager.checkPointIndex = index;
                Debug.Log("first check point");
               }
            }
    }
}
