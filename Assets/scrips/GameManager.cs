using NUnit.Framework;
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
    public GameObject[] currentTanks;
    public inputManager currentNode;
    public int playerNode;
    public AIInputManager AIcurrentNode;
    public int AINode;

    public bulletDeSpawn playerPoints;

    public float PlayerOnePoints = 0;
    public float playerTwoPoints =0;



    private void Awake()
    { 
        currentTanks = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        currentSpeed = speed.KPH;
        updateNeedle();


        //Debug.Log(PlayerOnePoints);
        //Debug.Log(AIPoints);

        playerNode = currentNode.currentNode;
        AINode = AIcurrentNode.AIcurrentNode;

       //Debug.Log(playerNode);
       //Debug.Log(AINode);
    }


    public void updateNeedle()
    {
        position = startPosition - endPosition;

        float temp = currentSpeed / 220F;

        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * position));
    }
}
