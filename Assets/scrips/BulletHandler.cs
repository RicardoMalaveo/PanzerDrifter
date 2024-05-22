using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BulletHandler : MonoBehaviour
{
    public float launchSpeed = 100.0f;
    private float ammo= 10F;
    private float ammoColdDown = 3F;
    public TMP_Text bulletCount;
    public Image Bullet;
    public GameObject objectPrefab;
    private AudioSource sonidoDisparo;
    public GameObject BulletSpawn;
    public RectTransform crosshair;
    public Camera cam;
    public OpcionesInGame gameState;

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


        if(ammo>=0)
        {
            if(ammo >=1 && Input.GetKeyDown(KeyCode.Mouse0) && gameState.gamePaused == false)
            {
                ammo -= 1;
                sonidoDisparo = GetComponent<AudioSource>();
                sonidoDisparo.PlayOneShot(sonidoDisparo.clip);
                SpawnObject();
            }

            if (ammo < 10)
            {
                Debug.Log("ammo spent");
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

    void SpawnObject() 
    {
        Vector3 SpawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;

        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);

        Vector3 velocity = localXDirection * launchSpeed;

        GameObject newObject = Instantiate(objectPrefab, SpawnPosition, spawnRotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }
}
