using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AIInputManager AINodes;
    public inputManager PlayerNodes;
    public sceneManager loadmenu;
    public TankDriverScript speed;
    public GameObject needle;
    public checkPointAndPointSystem currentlap;
    public TMP_Text playerPosition;
    public TMP_Text timer;
    public TMP_Text AIFirstLap;
    public TMP_Text AISecondLap;
    public TMP_Text AIThirdLap;
    public TMP_Text PlayerFirstLap;
    public TMP_Text PlayerSecondLap;
    public TMP_Text PlayerThirdLap;
    public TMP_Text AIDirectHitsTotal;
    public TMP_Text AIHitsTotal;
    public TMP_Text PlayerDirectHitsTotal;
    public TMP_Text PlayerHitsTotal;
    public TMP_Text lapCount;
    public GameObject EndGamePanel;
    public GameObject defeat;
    public GameObject Victory;
    private float startPosition = 180F;
    private float endPosition = -130F;
    private float needlePosition;
    public float currentSpeed;
    public float lapTimer;
    private float delay = 2F;

    private void Start()
    {
        timer.text = "0:00:00";
    }

    void Update()
    {        
        currentSpeed = speed.KPH;
        updateNeedle();
        PositionTracker();


        lapTimer = Mathf.Max(0, lapTimer + Time.deltaTime);
        var timeSpan = TimeSpan.FromSeconds(lapTimer);
        timer.text = timeSpan.Hours.ToString("0") + ":" +
                        timeSpan.Minutes.ToString("00") + ":" +
                        timeSpan.Seconds.ToString("00") + "." +
                        timeSpan.Milliseconds / 100;

        if (currentlap.playerLapNumber == 0)
        {
            lapCount.text = "1st Lap";
        }
        else if (currentlap.playerLapNumber == 1)
        {
            lapCount.text = "2nd Lap";
        }
        else
        {
            lapCount.text = "3rd Lap";
        }

        var playerFirstLap = TimeSpan.FromSeconds(currentlap.playerFirstLapTime);
        PlayerFirstLap.text = playerFirstLap.Hours.ToString("0") + ":" +
                        playerFirstLap.Minutes.ToString("00") + ":" +
                        playerFirstLap.Seconds.ToString("00") + "." +
                        playerFirstLap.Milliseconds / 100;

        var playerSecondLap = TimeSpan.FromSeconds(currentlap.playerSecondLapTime);
        PlayerSecondLap.text = playerSecondLap.Hours.ToString("0") + ":" +
                        playerSecondLap.Minutes.ToString("00") + ":" +
                        playerSecondLap.Seconds.ToString("00") + "." +
                        playerSecondLap.Milliseconds / 100;

        var playerThirdLap = TimeSpan.FromSeconds(currentlap.playerFinishTime);
        PlayerThirdLap.text = playerThirdLap.Hours.ToString("0") + ":" +
                        playerThirdLap.Minutes.ToString("00") + ":" +
                        playerThirdLap.Seconds.ToString("00") + "." +
                        playerThirdLap.Milliseconds / 100;

        var aIFirstLap = TimeSpan.FromSeconds(currentlap.AIFirstLapTime);
        AIFirstLap.text = aIFirstLap.Hours.ToString("0") + ":" +
                        aIFirstLap.Minutes.ToString("00") + ":" +
                        aIFirstLap.Seconds.ToString("00") + "." +
                        aIFirstLap.Milliseconds / 100;

        var aISecondLap = TimeSpan.FromSeconds(currentlap.AISecondLapTime);
        AISecondLap.text = aISecondLap.Hours.ToString("0") + ":" +
                        aISecondLap.Minutes.ToString("00") + ":" +
                        aISecondLap.Seconds.ToString("00") + "." +
                        aISecondLap.Milliseconds / 100;

        var aIThirdLap = TimeSpan.FromSeconds(currentlap.AIFinishTime);
        AIThirdLap.text = aIThirdLap.Hours.ToString("0") + ":" +
                        aIThirdLap.Minutes.ToString("00") + ":" +
                        aIThirdLap.Seconds.ToString("00") + "." +
                        aIThirdLap.Milliseconds / 100;

        AIDirectHitsTotal.text = currentlap.AIDirectHits.ToString();

        AIHitsTotal.text = currentlap.AIHits.ToString();

        PlayerDirectHitsTotal.text = currentlap.playerDirectHits.ToString();

        PlayerHitsTotal.text = currentlap.playerHits.ToString();


       if( currentlap.playerLapNumber ==3)
       {
            delay -= Time.deltaTime;
            if(delay <=0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if (currentlap.playerPoints > currentlap.AIPoints)
                {
                    EndGamePanel.SetActive(true);
                    Victory.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    EndGamePanel.SetActive(true);
                    defeat.SetActive(true);
                    Time.timeScale = 0;
                }
            }
       }
    }


    public void updateNeedle()
    {
        needlePosition = startPosition - endPosition;

        float temp = currentSpeed / 220F;

        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * needlePosition));
    }

    public void PositionTracker()
    {
        if(currentlap.playerLapNumber >= currentlap.AILapNumber)
        {
            if (PlayerNodes.currentNode > AINodes.AIcurrentNode || currentlap.playerLapNumber > currentlap.AILapNumber)
            {
                playerPosition.text = "1st Position";
            }
            else
            {
                playerPosition.text = "2nd Position";
            }

        }
        else
        {
            playerPosition.text = "2nd Position";
        }
    }
}
