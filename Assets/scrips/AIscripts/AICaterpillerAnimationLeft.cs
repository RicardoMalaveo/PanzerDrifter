using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICaterpillerAnimationLeft : MonoBehaviour
{
    public Animator AnimatorControlerLeft;
    public AIInputManager rotation;
    public float speedTank = 0F;

    public void Start()
    {
        AnimatorControlerLeft = GetComponent<Animator>();
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

        AnimatorControlerLeft.SetFloat("SpeedLeft", speedTank);

        if (rotation.horizontal < 0.2)
        {
            AnimatorControlerLeft.SetBool("Forward", true);
            AnimatorControlerLeft.SetBool("Backward", false);
        }
        else if (rotation.horizontal > 0.2)
        {
            AnimatorControlerLeft.SetBool("Backward", true);
            AnimatorControlerLeft.SetBool("Forward", false);
        }
        else
        {
            if (rotation.vertical >0)
            {
                AnimatorControlerLeft.SetBool("Forward", true);

            }

            if (rotation.vertical < 0)
            {
                AnimatorControlerLeft.SetBool("Backward", true);
            }

            if (rotation.vertical == 0)
            {
                AnimatorControlerLeft.SetBool("Forward", false);
                AnimatorControlerLeft.SetBool("Backward", false);
            }
        }


    }
}
