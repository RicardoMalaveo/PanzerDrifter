using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class bulletDeSpawn : MonoBehaviour
{
    public GameObject impactEffect;
    private void OnTriggerEnter()
    {
        
      GameObject EffectIns = (GameObject) Instantiate(impactEffect, transform.position,transform.rotation);
      Destroy(EffectIns, 1F);
      Destroy(gameObject,1F);
    }
}
