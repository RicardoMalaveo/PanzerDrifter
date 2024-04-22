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
    public Transform tankBody;


    public float launchSpeed = 100.0f;
    public GameObject objectPrefab;
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0F, 2F);
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
