using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointAndPointSystem : MonoBehaviour
{
    public int playerCheckPointIndex;
    public int AICheckPointIndex;

    public int playerLapNumber;
    public int AILapNumber;

    public float AIPoints;
    public float playerPoints;

    public float playerFirstLapTime;
    public float AIFirstLapTime;

    public float playerSecondLapTime;
    public float AISecondLapTime;

    public float playerFinishTime;
    public float AIFinishTime;

    public float playerDirectHits;
    public float AIDirectHits;

    public float playerHits;
    public float AIHits;

    public void Start()
    {
        playerCheckPointIndex = 0;
        AICheckPointIndex = 0;

        playerLapNumber = 0;
        AILapNumber = 0;

        playerPoints = 0;
        AIPoints = 0;
    }

}
