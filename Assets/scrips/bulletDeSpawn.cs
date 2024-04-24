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
    private float torqueMininum =0F;

    private void OnTriggerEnter(Collider other)
    {
       

        GameObject EffectIns = Instantiate(impactEffect, transform.position,transform.rotation);
        Destroy(EffectIns, 1F);
        Destroy(gameObject,0F);
        


    }

    private void Update(Collider other)
    {
        TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();
        AIController AIDamageControl = FindAnyObjectByType<AIController>();
        if (other.tag == "Enemy")
        {
            //TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();
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


        if (other.tag == "AIEnemy")
        {
            //AIController AIDamageControl = FindAnyObjectByType<AIController>();
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

        //TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();

        if (DamageControl.torqueLeft >= DamageControl.torqueMaxLeft)
        {
            DamageControl.torqueLeft = DamageControl.torqueMaxLeft;
        }
        else
        {
            DamageControl.torqueLeft += torqueRecover * Time.deltaTime / 2F;
        }

        if (DamageControl.torqueRight >= DamageControl.torqueMaxRight)
        {
            DamageControl.torqueRight = DamageControl.torqueMaxRight;
        }
        else
        {
            DamageControl.torqueRight += torqueRecover * Time.deltaTime / 2F;
        }

        //AIController AIDamageControl = FindAnyObjectByType<AIController>();

        if (AIDamageControl.torqueLeft >= AIDamageControl.torqueMaxLeft)
        {
            AIDamageControl.torqueLeft = AIDamageControl.torqueMaxLeft;
        }
        else
        {
            AIDamageControl.torqueLeft += torqueRecover * Time.deltaTime / 2F;
        }

        if (AIDamageControl.torqueRight >= AIDamageControl.torqueMaxRight)
        {
            AIDamageControl.torqueRight = AIDamageControl.torqueMaxRight;
        }
        else
        {
            AIDamageControl.torqueRight += torqueRecover * Time.deltaTime/2F;
        }
    }
}
