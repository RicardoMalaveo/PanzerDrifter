using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float launchSpeed = 100.0f;
    public GameObject objectPrefab;
    private AudioSource sonidoDisparo;
    public GameObject BulletSpawn;
    public RectTransform crosshair;
    public Camera cam;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                RaycastHit hit;
        if (Physics.Raycast(BulletSpawn.transform.position, BulletSpawn.transform.forward, out hit))
        {
            if (hit.collider)
            {
                crosshair.position = cam.WorldToScreenPoint(hit.point);
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            sonidoDisparo = GetComponent<AudioSource>();
            sonidoDisparo.PlayOneShot(sonidoDisparo.clip);
            SpawnObject(); 
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
