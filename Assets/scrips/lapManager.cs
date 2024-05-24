using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapManager : MonoBehaviour
{
    public List<checkPointManager> checkpoints;
    private float totalLaps = 3;


    private void OnTriggerEnter(Collider other)
    {
        checkPointAndPointSystem CheckPointManager = FindAnyObjectByType<checkPointAndPointSystem>();
        GameManager timers = FindAnyObjectByType<GameManager>();

        if (other.tag == "Enemy")
        {
            if (CheckPointManager.playerCheckPointIndex <3)
            {
                Debug.Log("going the wrong way");
            }
            else if (CheckPointManager.playerCheckPointIndex == checkpoints.Count)
            {
                
                CheckPointManager.playerCheckPointIndex = 0;
                CheckPointManager.playerLapNumber++;

                if (CheckPointManager.playerLapNumber == 1F)
                {
                    CheckPointManager.playerFirstLapTime = timers.lapTimer;

                    if(CheckPointManager.AIFirstLapTime > 0) 
                    {
                        if(CheckPointManager.playerFirstLapTime < CheckPointManager.AIFirstLapTime)
                        {
                            CheckPointManager.playerPoints += 1000F;
                        }
                        else
                        {
                            CheckPointManager.AIPoints += 1000F;
                        }
                    }
                    else
                    {
                        CheckPointManager.playerPoints += 1000F;
                    }
                }

                if (CheckPointManager.playerLapNumber == 2F)
                {
                    CheckPointManager.playerSecondLapTime = timers.lapTimer;


                    if (CheckPointManager.AISecondLapTime > 0)
                    {
                        if (CheckPointManager.playerSecondLapTime < CheckPointManager.AISecondLapTime)
                        {
                            CheckPointManager.playerPoints += 1000F;
                        }
                        else
                        {
                            CheckPointManager.AIPoints += 1000F;
                        }
                    }
                    else
                    {
                        CheckPointManager.playerPoints += 1000F;
                    }
                }

                if (CheckPointManager.playerLapNumber >= totalLaps)
                {
                    Debug.Log("finish timer");
                    CheckPointManager.playerFinishTime = timers.lapTimer;

                    if (CheckPointManager.AIFinishTime >= 0)
                    {
                        if (CheckPointManager.playerFinishTime < CheckPointManager.AIFinishTime)
                        {
                            CheckPointManager.playerPoints += 2000F;
                        }
                        else
                        {
                            CheckPointManager.AIPoints += 2000F;
                        }
                    }
                    else
                    {
                        CheckPointManager.playerPoints += 2000F;

                    }
                }
            }
        }


        if (other.tag == "AITBody")
        {
            if (CheckPointManager.AILapNumber >= totalLaps)
            {
                CheckPointManager.AIFinishTime = timers.lapTimer;

            }
            else if (CheckPointManager.AICheckPointIndex == checkpoints.Count)
            {
                CheckPointManager.AICheckPointIndex = 0;
                CheckPointManager.AILapNumber++;

                if (CheckPointManager.AILapNumber == 1F)
                {
                    CheckPointManager.AIFirstLapTime = timers.lapTimer;
                }

                if (CheckPointManager.AILapNumber == 2F)
                {
                    CheckPointManager.AISecondLapTime = timers.lapTimer;
                }

                if (CheckPointManager.AILapNumber == 3F)
                {
                    CheckPointManager.AIFinishTime = timers.lapTimer;
                }
            }
        }
    }
}
