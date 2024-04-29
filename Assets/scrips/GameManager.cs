using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TankDriverScript speed;
    public GameObject needle;
    private float startPosition = 180F;
    private float endPosition = -130F;
    private float position;
    public float currentSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = speed.KPH;
        updateNeedle();

    }


    public void updateNeedle()
    {
        position = startPosition - endPosition;

        float temp = currentSpeed / 220F;

        needle.transform.eulerAngles = new Vector3(0,0,(startPosition - temp * position));
    }
}
