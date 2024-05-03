using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TankDriverScript speed;
    public GameObject needle;
    public checkPointAndPointSystem currentlap;
    public TMP_Text timer;
    public TMP_Text lapCount;
    public GameObject victoryPanel;
    public GameObject defeatPanel;
    private float startPosition = 180F;
    private float endPosition = -130F;
    private float position;
    public float currentSpeed;
    public float lapTimer;
    public bool victory;

    private void Start()
    {
        timer.text = "0:00:00";
    }

    void Update()
    {        
        currentSpeed = speed.KPH;
        updateNeedle();

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



        lapTimer = Mathf.Max(0, lapTimer + Time.deltaTime);
        var timeSpan = TimeSpan.FromSeconds(lapTimer);
        timer.text = timeSpan.Hours.ToString("0") + ":" +
                        timeSpan.Minutes.ToString("00") + ":" +
                        timeSpan.Seconds.ToString("00") + "." +
                        timeSpan.Milliseconds / 100;

       if( currentlap.playerLapNumber ==3)
        {
            if (currentlap.playerPoints > currentlap.AIPoints)
            {
                victoryPanel.SetActive(true);
                Time.timeScale = 0F;
            }
            else
            {
                defeatPanel.SetActive(true);
                Time.timeScale = 0F;
            }
        }

       if (victory== true)
        {
            victoryPanel.SetActive(true);

        }

    }


    public void updateNeedle()
    {
        position = startPosition - endPosition;

        float temp = currentSpeed / 220F;

        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * position));
    }
}
