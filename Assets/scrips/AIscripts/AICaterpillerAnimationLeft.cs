using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICaterpillerAnimationLeft : MonoBehaviour
{
    public Animator AIAnimatorControlerLeft;
    public AIInputManager rotation;
    public float speedTank = 0F;

    public void Start()
    {
        AIAnimatorControlerLeft = GetComponent<Animator>();
    }

    public void Update()
    {
        if (rotation.horizontal < 0.2 || rotation.horizontal > 0.2 || rotation.horizontal < 0.2 || rotation.horizontal > 0.2)
        {
            if (speedTank > 5)
            {
                speedTank = 5;
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

        AIAnimatorControlerLeft.SetFloat("SpeedLeft", speedTank);

        if (rotation.horizontal < 0.2)
        {
            AIAnimatorControlerLeft.SetBool("Forward", true);
            AIAnimatorControlerLeft.SetBool("Backward", false);
        }
        else if (rotation.horizontal > 0.2)
        {
            AIAnimatorControlerLeft.SetBool("Backward", true);
            AIAnimatorControlerLeft.SetBool("Forward", false);
        }
        else
        {
            if (rotation.vertical >0)
            {
                AIAnimatorControlerLeft.SetBool("Forward", true);

            }

            if (rotation.vertical < 0)
            {
                AIAnimatorControlerLeft.SetBool("Backward", true);
            }

            if (rotation.vertical == 0)
            {
                AIAnimatorControlerLeft.SetBool("Forward", false);
                AIAnimatorControlerLeft.SetBool("Backward", false);
            }
        }


    }
}
