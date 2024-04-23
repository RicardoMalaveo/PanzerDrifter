using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class bulletDeSpawn : MonoBehaviour
{
    public GameObject impactEffect;

    public float torqueReductor;
    private void OnTriggerEnter()
    {
      GameObject EffectIns = Instantiate(impactEffect, transform.position,transform.rotation);
      Destroy(EffectIns, 1F);
      Destroy(gameObject,1F);

        //TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();
        //DamageControl.torqueLeft -= torqueReductor;
        //DamageControl.torqueRight -= torqueReductor;

    }
}
