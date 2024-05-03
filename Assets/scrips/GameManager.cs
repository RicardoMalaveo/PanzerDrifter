using NUnit.Framework;
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
    public TMP_Text timer;
    private float startPosition = 180F;
    private float endPosition = -130F;
    private float position;
    public float currentSpeed;
    public float lapTimer;

    private void Start()
    {
        timer.text = "0:00:00";
    }

    void Update()
    {
        currentSpeed = speed.KPH;
        updateNeedle();

        lapTimer = Mathf.Max(0, lapTimer + Time.deltaTime);
        var timeSpan = TimeSpan.FromSeconds(lapTimer);
        timer.text = timeSpan.Hours.ToString("0") + ":" +
                        timeSpan.Minutes.ToString("00") + ":" +
                        timeSpan.Seconds.ToString("00") + "." +
                        timeSpan.Milliseconds / 100;        
        Debug.Log(lapTimer);
    }


    public void updateNeedle()
    {
        position = startPosition - endPosition;

        float temp = currentSpeed / 220F;

        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * position));
    }
}
