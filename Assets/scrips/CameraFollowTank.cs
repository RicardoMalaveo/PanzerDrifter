using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTank : MonoBehaviour
{
    public Transform reset;
    public Transform objectToFollow; 
    public Transform objectToFollowBody;

    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;
    [SerializeField][Range(0, 10)] float rotationSpeed = 0.5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            objectToFollow = objectToFollowBody;

        }
        else
        {
            objectToFollow = reset;
        }
    }
    public void LookAtTarget()
    {
        Vector3 lookDirection = objectToFollow.position - transform.position; 
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }
    
    public void MoveToTarget()
    {
        Vector3 targerPosition = objectToFollow.position + objectToFollow.forward * offset.z + objectToFollow.right * offset.x + objectToFollow.up * offset.y;

        transform.position = Vector3.Lerp(transform.position, targerPosition, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget(); 
    }
}
