using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public bool handbreak;
    public AITankWayPoints TankWayPoints;

    public List<Transform> nodes = new List<Transform>();
    public Transform currentWayPoint;
    public int currentNode;
    [Range(0, 10)] public int distanceOffset;

    private void Awake()
    {
        TankWayPoints = GameObject.FindGameObjectWithTag("Path").GetComponent<AITankWayPoints>();
        nodes = TankWayPoints.nodes;
    }

    private void FixedUpdate()
    {
        Keyboard();
        WayPointDistanceCalculator();
    }
    void Start()
    {
        Cursor.visible = false;
    }
    private void Keyboard()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        handbreak = Input.GetKey(KeyCode.Space);
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
                    currentNode = i;
                }
            }
        }
        catch
        {
        }
    }
}
