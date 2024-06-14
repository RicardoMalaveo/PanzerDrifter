using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillerAnimationRight : MonoBehaviour
{
    public Animator AnimatorControlerRight;
    public TankDriverScript TankDriverScript;
    public float speedTank= 0F;


    public void Start()
    {
        AnimatorControlerRight = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (speedTank > 5)
            {
                speedTank = 5;
            }
            speedTank += Time.deltaTime;
        }
        else
        {
            if (speedTank <0)
            {
                speedTank = 0;
            }
            speedTank -= Time.deltaTime;
        }

        AnimatorControlerRight.SetFloat("SpeedRight", speedTank);
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
