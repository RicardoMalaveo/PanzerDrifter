using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointAndPointSystem : MonoBehaviour
{
    public int playerLapNumber;
    public int AILapNumber;

    public int playerCheckPointIndex;
    public int AICheckPointIndex;
    public float AIPoints;
    public float playerPoints;

    public void Start()
    {
        playerLapNumber = 1;
        AILapNumber = 1;
        playerCheckPointIndex = 0;
        AICheckPointIndex = 0;
        playerPoints = 0;
        AIPoints = 0;
    }
    public void Update()
    {
        Debug.Log(playerPoints);
        Debug.Log(AIPoints);
    }
}
