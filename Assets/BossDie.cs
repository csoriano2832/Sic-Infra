using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : StateMachineBehaviour
{
    private float waitTime = 0;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTime += Time.deltaTime;
        if (waitTime >= 2)
        {
            animator.SetTrigger("Dissappear");
        }
    }
}
