using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageControl : MonoBehaviour
{
    public float torqueRecover;


    void Update()
    {
        TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();

        if (DamageControl.torqueLeft < DamageControl.torqueMaxLeft)
        {
            DamageControl.torqueLeft += torqueRecover * Time.deltaTime / 2F;
        }


        if (DamageControl.torqueRight < DamageControl.torqueMaxRight)
        {
            DamageControl.torqueRight += torqueRecover * Time.deltaTime / 2F;
        }


        AIController AIDamageControl = FindAnyObjectByType<AIController>();

        if (AIDamageControl.torqueLeft < AIDamageControl.torqueMaxLeft)
        {
            AIDamageControl.torqueLeft += torqueRecover * Time.deltaTime / 2F;
        }

        if (AIDamageControl.torqueRight < AIDamageControl.torqueMaxRight)
        {
            AIDamageControl.torqueRight += torqueRecover * Time.deltaTime / 2F;
        }
    }
}
