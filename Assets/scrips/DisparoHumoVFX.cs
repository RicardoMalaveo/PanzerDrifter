using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DisparoHumoVFX : MonoBehaviour
{
    public VisualEffect visualEffect;
    public Transform bulletSpawn; // Referencia al objeto BulletSpawn
    public BulletHandler bulletHandler;


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
        Debug.Log("DispararHumo llamado"); // Mensaje de depuraci�n
        if (visualEffect != null && bulletSpawn != null)
        {
            // Obtener la posici�n y rotaci�n local del BulletSpawn
            Vector3 localSpawnPosition = bulletSpawn.localPosition;
            Quaternion localSpawnRotation = bulletSpawn.localRotation;

            // Convertir la posici�n y rotaci�n local a posici�n y rotaci�n global
            Vector3 globalSpawnPosition = bulletSpawn.parent.TransformPoint(localSpawnPosition);
            Quaternion globalSpawnRotation = bulletSpawn.parent.rotation * localSpawnRotation;

            // Establecer la posici�n y rotaci�n de spawn del humo
            visualEffect.transform.position = globalSpawnPosition;
            visualEffect.transform.rotation = globalSpawnRotation;

            // Activar el efecto de humo
            Debug.Log("Invoco el effecto de humo");
            visualEffect.SendEvent("OnPlay");
        }
    }
}