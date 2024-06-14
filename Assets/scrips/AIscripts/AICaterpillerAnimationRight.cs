using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICaterpillerAnimationRight : MonoBehaviour
{
    public Animator AIAnimatorControlerRight;
    public AIInputManager rotation;
    public float speedTank = 0F;



    public void Start()
    {
        AIAnimatorControlerRight = GetComponent<Animator>();
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

        AIAnimatorControlerRight.SetFloat("SpeedRight", speedTank);

        if (rotation.horizontal < 0.2)
        {
            AIAnimatorControlerRight.SetBool("Forward", false);
            AIAnimatorControlerRight.SetBool("Backward", true);
        }
        else if (rotation.horizontal > 0.2)
        {
            AIAnimatorControlerRight.SetBool("Backward", false);
            AIAnimatorControlerRight.SetBool("Forward", true);
        }
        else
        {
            if (rotation.vertical > 0)
            {
                AIAnimatorControlerRight.SetBool("Forward", true);

            }

            if (rotation.vertical < 0)
            {
                AIAnimatorControlerRight.SetBool("Backward", true);
            }

            if (rotation.vertical == 0)
            {
                AIAnimatorControlerRight.SetBool("Forward", false);
                AIAnimatorControlerRight.SetBool("Backward", false);
            }
        }
    }
}
