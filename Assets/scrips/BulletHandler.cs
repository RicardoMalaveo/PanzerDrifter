using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float launchSpeed = 100.0f;
    public GameObject objectPrefab;
    private AudioSource sonidoDisparo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
