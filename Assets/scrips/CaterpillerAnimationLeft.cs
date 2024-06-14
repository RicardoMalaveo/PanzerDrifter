using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillerAnimationLeft : MonoBehaviour
{
    public Animator AnimatorControlerLeft;

    public float speedTank=0F;



    public void Start()
    {
        AnimatorControlerLeft = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            if (speedTank > 6)
            {
                speedTank = 6;
            }
            speedTank += Time.deltaTime;
        }
        else
        {
            if (speedTank < 0)
            {
                speedTank = 0;
            }
            speedTank -= Time.deltaTime;
        }

        AnimatorControlerLeft.SetFloat("SpeedLeft", speedTank);

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
