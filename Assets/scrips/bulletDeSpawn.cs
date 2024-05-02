using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDeSpawn : MonoBehaviour
{
    public GameObject impactEffect;
    public float torqueReductor;
    private float torqueMininum = 0F;


    public void OnTriggerEnter(Collider other)
    {

        GameObject EffectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(EffectIns, 1F);
        Destroy(gameObject, 1F);

        checkPointAndPointSystem points = FindAnyObjectByType<checkPointAndPointSystem>();

        if (other.tag == "PlayerTBody")
            {
            points.AIPoints += 50F;
        }

        if (other.tag == "PlayerOL")
            {
            points.AIPoints += 100F;
        }

        if (other.tag == "PlayerOD")
        {
            points.AIPoints += 100F;

        }

        if (other.tag == "AITBody")
        {
            points.playerPoints += 50F;
        }

        if (other.tag == "AIOL")
        {
            points.playerPoints += 100F;
        }

        if (other.tag == "AIOD")
        {
            points.playerPoints += 100F;
        }

        TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();

        AIController AIDamageControl = FindAnyObjectByType<AIController>();

        if (other.tag == "PlayerTBody")
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

        if (other.tag == "PlayerOL")
        {
            if (DamageControl.torqueLeft <= torqueMininum)
            {
            }
            else
            {
                DamageControl.torqueLeft -= torqueReductor;

            }
        }

        if (other.tag == "PlayerOD")
        {
            if (DamageControl.torqueRight <= torqueMininum)
            {
            }
            else
            {
                DamageControl.torqueRight -= torqueReductor;

            }
        }



        //AIController AIDamageControl = FindAnyObjectByType<AIController>();
        if (other.tag == "AITBody")
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

        if (other.tag == "AIOL")
        {
            if (AIDamageControl.torqueLeft <= torqueMininum)
            {
            }
            else
            {
                AIDamageControl.torqueLeft -= torqueReductor;
            }
        }

        if (other.tag == "AIOD")
        {
            if (AIDamageControl.torqueRight <= torqueMininum)
            {
            }
            else
            {

                AIDamageControl.torqueRight -= torqueReductor;
            }
        }
    }

}
