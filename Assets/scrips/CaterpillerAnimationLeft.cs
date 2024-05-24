using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillerAnimationLeft : MonoBehaviour
{
    public Animator AnimatorControlerLeft;


    public void Start()
    {
        AnimatorControlerLeft = GetComponent<Animator>();
    }

    public void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            AnimatorControlerLeft.SetBool("Forward", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AnimatorControlerLeft.SetBool("Backward", true);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                AnimatorControlerLeft.SetBool("Forward", true);

            }

            if (Input.GetKey(KeyCode.S))
            {
                AnimatorControlerLeft.SetBool("Backward", true);
            }


            if (!Input.GetKey(KeyCode.W))
            {
                AnimatorControlerLeft.SetBool("Forward", false);
            }

            if (!Input.GetKey(KeyCode.S))
            {
                AnimatorControlerLeft.SetBool("Backward", false);
            }
        }


    }
}
