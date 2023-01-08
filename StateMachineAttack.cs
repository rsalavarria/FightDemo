using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineAttack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("IdleCombat"))
        {
            ComboController.instance.ResetCombo();
        }
        ComboController.instance.canReceiveInput = true;
        //ComboController.instance.inputReceived = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ComboController.instance.inputReceived)
        {
            int nextAttackIndex = ComboController.instance.attackIndex++;
            animator.SetTrigger(ComboController.instance.attacks[nextAttackIndex]);
            //ComboController.instance.swordDamage.gameObject.SetActive(true);
            ComboController.instance.inputReceived = false;
            ComboController.instance.canReceiveInput = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //ComboController.instance.swordDamage.gameObject.SetActive(false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
