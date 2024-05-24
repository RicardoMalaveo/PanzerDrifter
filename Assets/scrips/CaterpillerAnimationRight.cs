using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillerAnimationRight : MonoBehaviour
{
    public Animator AnimatorControlerRight;


    public void Start()
    {
        AnimatorControlerRight = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            AnimatorControlerRight.SetBool("Backward", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AnimatorControlerRight.SetBool("Forward", true);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                AnimatorControlerRight.SetBool("Forward", true);

            }

            if (!Input.GetKey(KeyCode.W))
            {
                AnimatorControlerRight.SetBool("Forward", false);
            }


            if (Input.GetKey(KeyCode.S))
            {
                AnimatorControlerRight.SetBool("Backward", true);
            }


            if (!Input.GetKey(KeyCode.S))
            {
                AnimatorControlerRight.SetBool("Backward", false);
            }
        }
    }
}
