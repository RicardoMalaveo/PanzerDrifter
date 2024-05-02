using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject Wall;
    void Update()
    {

        GameObject murito = Instantiate(Wall, transform.position, transform.rotation);
        Destroy(Wall, 3F);
    }
}
