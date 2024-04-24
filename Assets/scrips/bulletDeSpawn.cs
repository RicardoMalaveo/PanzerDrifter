using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class bulletDeSpawn : MonoBehaviour
{
    public GameObject impactEffect;
    public bool hitDetection;

    public float torqueReductor;
    public float torqueRecover;
    private float torqueMininum = 0F;

    private void OnTriggerEnter(Collider other)
    {


        GameObject EffectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(EffectIns, 1F);
        Destroy(gameObject, 0F);

        TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();
        AIController AIDamageControl = FindAnyObjectByType<AIController>();

        //TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();
        if (other.tag == "Enemy")
        {
            if (DamageControl.torqueLeft <= torqueMininum)
        {

        }
        else
        {
            DamageControl.torqueLeft -= torqueReductor;
        }

        if (DamageControl.torqueRight <= torqueMininum)
        {

        }
        else
        {
            DamageControl.torqueRight -= torqueReductor;
        }
        }


        //AIController AIDamageControl = FindAnyObjectByType<AIController>();
        if (other.tag == "AIEnemy")
        {
        if (AIDamageControl.torqueLeft <= torqueMininum)
        {

        }
        else
        {
            AIDamageControl.torqueLeft -= torqueReductor;
        }

        if (AIDamageControl.torqueRight <= torqueMininum)
        {

        }
        else
        {
            AIDamageControl.torqueRight -= torqueReductor;
        }
        }

    }

    private void Update()
    {


        TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();

        if (DamageControl.torqueLeft < DamageControl.torqueMaxLeft)
        {
            DamageControl.torqueLeft += torqueRecover * Time.deltaTime / 4;
        }


        if (DamageControl.torqueRight < DamageControl.torqueMaxRight)
        {
            DamageControl.torqueRight += torqueRecover * Time.deltaTime/4;
        }


        AIController AIDamageControl = FindAnyObjectByType<AIController>();

        if (AIDamageControl.torqueLeft < AIDamageControl.torqueMaxLeft)
        {
            AIDamageControl.torqueLeft += torqueRecover * Time.deltaTime / 4;
        }

        if (AIDamageControl.torqueRight < AIDamageControl.torqueMaxRight)
        {
            AIDamageControl.torqueRight += torqueRecover * Time.deltaTime / 4;
        }
    }
}
