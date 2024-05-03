using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class turretRotationAI : MonoBehaviour
{
    private Transform target ;
    public float range = 120F;
    public string enemyTag = "Enemy";
    public Transform Turret;
    public float turretRotationSpeed = 15F;
    public GameObject objectPrefab;
    public float fireRate = 1F;
    private float fireCountDown = 5F;
    public float launchSpeed = 450F;
    private AudioSource sonidoDisparo;
    public Transform bulletspawn;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0F, 0.5F);
    }
    void UpdateTarget()
    {
        GameObject [] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) 
            {
                shortestDistance = distanceToEnemy; 
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        //turret rotation to target
        Vector3 direction = target.position - transform.position;
        Quaternion LookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp (Turret.rotation, LookRotation, Time.deltaTime * turretRotationSpeed).eulerAngles;
        Turret.rotation = Quaternion.Euler(0F, rotation.y, 0F);

        if (fireCountDown <= 0F)
        {
            Shoot();
            fireCountDown = 1F / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public void Shoot()
    {
        sonidoDisparo = GetComponent<AudioSource>();
        sonidoDisparo.PlayOneShot(sonidoDisparo.clip);

        Vector3 SpawnPosition = bulletspawn.transform.position;
        Quaternion spawnRotation = Quaternion.identity;

        Vector3 localXDirection = bulletspawn.transform.TransformDirection(Vector3.forward);

        Vector3 velocity = localXDirection * launchSpeed;

        GameObject newObject = Instantiate(objectPrefab, SpawnPosition, spawnRotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }

}
