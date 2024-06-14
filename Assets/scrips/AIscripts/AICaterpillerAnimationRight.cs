using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICaterpillerAnimationRight : MonoBehaviour
{
    public Animator AnimatorControlerRight;
    public AIInputManager rotation;
    public float speedTank = 0F;



    public void Start()
    {
        AnimatorControlerRight = GetComponent<Animator>();
    }

    public void Update()
    {
        if (rotation.horizontal < 0.2 || rotation.horizontal > 0.2 || rotation.horizontal < 0.2 || rotation.horizontal > 0.2)
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

        AnimatorControlerRight.SetFloat("SpeedRight", speedTank);

        if (rotation.horizontal < 0.2)
        {
            AnimatorControlerRight.SetBool("Forward", false);
            AnimatorControlerRight.SetBool("Backward", true);
        }
        else if (rotation.horizontal > 0.2)
        {
            AnimatorControlerRight.SetBool("Backward", false);
            AnimatorControlerRight.SetBool("Forward", true);
        }
        else
        {
            if (rotation.vertical > 0)
            {
                AnimatorControlerRight.SetBool("Forward", true);

            }

            if (rotation.vertical < 0)
            {
                AnimatorControlerRight.SetBool("Backward", true);
            }

            if (rotation.vertical == 0)
            {
                AnimatorControlerRight.SetBool("Forward", false);
                AnimatorControlerRight.SetBool("Backward", false);
            }
        }
    }
}
