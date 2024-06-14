using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DisparoHumoVFX : MonoBehaviour
{
    public VisualEffect visualEffect;
    public Transform bulletSpawn;
    public BulletHandler bulletHandler;
    public turretRotationAI turretRotationAI;


    void Start()
    {
        if (visualEffect == null)
        {
            visualEffect = GetComponent<VisualEffect>();
        }

        if (bulletHandler != null)
        {
            bulletHandler.OnDisparo += DispararHumo;
        }

        if (visualEffect == null)
        {
            visualEffect = GetComponent<VisualEffect>();
        }

        if (turretRotationAI != null)
        {
            turretRotationAI.OnDisparo += DispararHumo;
        }
    }

    void OnDestroy()
    {
        if (bulletHandler != null)
        {
            bulletHandler.OnDisparo -= DispararHumo;
        }
    }

    public void DispararHumo()
    {
        if (visualEffect != null && bulletSpawn != null)
        {
            // Obtener la posición y rotación local del BulletSpawn
            Vector3 localSpawnPosition = bulletSpawn.localPosition;
            Quaternion localSpawnRotation = bulletSpawn.localRotation;

            // Convertir la posición y rotación local a posición y rotación global
            Vector3 globalSpawnPosition = bulletSpawn.parent.TransformPoint(localSpawnPosition);
            Quaternion globalSpawnRotation = bulletSpawn.parent.rotation * localSpawnRotation;

            // Establecer la posición y rotación de spawn del humo
            visualEffect.transform.position = globalSpawnPosition;
            visualEffect.transform.rotation = globalSpawnRotation;
            visualEffect.SendEvent("OnPlay");
        }
    }
}