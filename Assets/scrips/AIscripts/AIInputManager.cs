using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputManager : MonoBehaviour
{
    public GameObject prefabInstance;
    public float increaseYAmount = 1.0f;
    public float vertical;
    public float horizontal;
    public bool handbreak;
    public AITankWayPoints TankWayPoints;
    public List<Transform> nodes = new List<Transform>();
    public Transform currentWayPoint;
    [Range(0, 10)] public int distanceOffset;
    [Range(0, 10)] public float rotationSpeed;
    public int AIcurrentNode;
    public int nodeCheck = 0;
    public float flippedTimer = 5F;


    private void Awake()
    {
        TankWayPoints = GameObject.FindGameObjectWithTag("Path").GetComponent<AITankWayPoints>();
        nodes = TankWayPoints.nodes;
    }
    private void FixedUpdate()
    {
        AIDrive();
        WayPointDistanceCalculator();
        FlipChecker();
    }

    private void AIDrive()
    {
        vertical = 0.7F;
        AIRotation();
    }
    private void AIRotation()
    {
        //horizontal tank rotation
        Vector3 relative = transform.InverseTransformPoint(currentWayPoint.transform.position);
        relative /= relative.magnitude;


        horizontal = (relative.x / relative.magnitude) * rotationSpeed;
    }
    private void WayPointDistanceCalculator()
    {
        try
        {
            Vector3 position = gameObject.transform.position;
            float distance = Mathf.Infinity;

            for (int i = 0; i < nodes.Count; i++)
            {
                Vector3 difference = nodes[i].transform.position - position;
                float currentDistance = difference.magnitude;
                if (currentDistance < distance)
                {
                    if ((i + distanceOffset) >= nodes.Count)
                    {
                        currentWayPoint = nodes[1];
                        distance = currentDistance;
                    }
                    else
                    {
                        currentWayPoint = nodes[i + distanceOffset];
                        distance = currentDistance;
                    }
                    AIcurrentNode = i;
                }
            }
        }
        catch
        {
        }
    }
    public void FlipChecker()
    {
        if (nodeCheck == AIcurrentNode) 
        {
            flippedTimer-= Time.deltaTime;

            if (flippedTimer <= 0)
            {
                Vector3 newPosition = prefabInstance.transform.position;
                newPosition.y += increaseYAmount;
                prefabInstance.transform.position = newPosition;
                float currentRotationY = prefabInstance.transform.rotation.eulerAngles.y;
                prefabInstance.transform.rotation = Quaternion.Euler(0, currentRotationY, 0);

                flippedTimer = 5F;
            }
        }
        else
        {
            nodeCheck = AIcurrentNode;
            flippedTimer = 5F;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(currentWayPoint.position, 3);
    }
}
