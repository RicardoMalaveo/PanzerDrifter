using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICaterpillerAnimationRight : MonoBehaviour
{
    public Animator AnimatorControlerRight;
    public AIInputManager rotation;


    public void Start()
    {
        AnimatorControlerRight = GetComponent<Animator>();
    }

    public void Update()
    {

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
