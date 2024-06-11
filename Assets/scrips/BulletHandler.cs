using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BulletHandler : MonoBehaviour
{
    public Transform barrel;
    public float launchSpeed = 100.0f;
    private float ammo = 10F;
    private float ammoColdDown = 3F;
    public TMP_Text bulletCount;
    public Image Bullet;
    public GameObject objectPrefab;
    private AudioSource sonidoDisparo;
    public GameObject BulletSpawn;
    public RectTransform crosshair;
    public Camera cam;
    public OpcionesInGame gameState;
    public DisparoHumoVFX disparoHumoVFX; // Referencia al script DisparoHumoVFX

    // Definir un delegado y un evento
    public delegate void DisparoEventHandler();
    public event DisparoEventHandler OnDisparo;
    public GameObject bulletSpawnPoint; // GameObject que representa el punto de spawn del humo
    public GameObject SpawnSmoke;
    void Start()
    {
        sonidoDisparo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletCount.text = "X" + ammo.ToString();

        if (ammo > 6F)
        {
            Bullet.color = Color.green;
        }
        else if (ammo > 3)
        {
            Bullet.color = Color.yellow;
        }
        else if (ammo > 0)
        {
            Bullet.color = Color.red;
        }
        else
        {
            Bullet.color = Color.black;
        }

        RaycastHit hit;
        if (Physics.Raycast(BulletSpawn.transform.position, BulletSpawn.transform.forward, out hit))
        {
            crosshair.position = cam.WorldToScreenPoint(hit.point);
        }

        if (ammo >= 0)
        {
            if (ammo >= 1 && Input.GetKeyDown(KeyCode.Mouse0) && !gameState.gamePaused)
            {
                ammo -= 1;
                sonidoDisparo.PlayOneShot(sonidoDisparo.clip);
                SpawnObject();

                // Disparar el evento OnDisparo
                if (OnDisparo != null)
                {
                    Debug.Log("Evento OnDisparo invocado"); // Mensaje de depuración
                    OnDisparo.Invoke();
                }
            }

            if (ammo < 10)
            {
                //Debug.Log("ammo spent");
                ammoColdDown -= Time.deltaTime;

                if (ammoColdDown <= 0)
                {
                    Debug.Log("reloading");
                    ammoColdDown = 3f;
                    ammo += 1;
                }
            }
        }
    }

    // Método para spawnear el humo en la posición del bulletSpawnPoint
    void SpawnHumo()
    {
        // Obtener la posición del punto de spawn del humo
        Vector3 spawnPosition = bulletSpawnPoint.transform.position;

        // Spawnear el humo en la posición del bulletSpawnPoint
        Instantiate(SpawnSmoke, spawnPosition, Quaternion.identity);
    }
    void SpawnObject()
    {
        Vector3 SpawnPosition = transform.position;
        Quaternion spawnRotation = barrel.rotation;

        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);

        Vector3 velocity = localXDirection * launchSpeed;

        GameObject newObject = Instantiate(objectPrefab, SpawnPosition, spawnRotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }
}
