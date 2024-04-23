using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHandlerAI : MonoBehaviour
{
    public float fireRate = 1F;
    private float fireCountDown = 0F;
    public float launchSpeed = 100.0f;
    public GameObject objectPrefab;
    private AudioSource sonidoDisparo;
    void Update()
    {
        if (fireCountDown <= 0F)
        {
            sonidoDisparo = GetComponent<AudioSource>();
            sonidoDisparo.PlayOneShot(sonidoDisparo.clip);
            Shoot();
            fireCountDown = 1F / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    void Shoot()
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
