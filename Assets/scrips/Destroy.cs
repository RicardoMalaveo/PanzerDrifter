using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject Wall;
    void Start()
    {
        Destroy(Wall, 5F);
    }
}
