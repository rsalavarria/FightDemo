using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Ability
{
    Animator animator;

    public Collider damageCollider;

    [Header("Animation Parameters")]
    public string attackAnimatorParameter;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Prepare()
    {
        if (!isExecuting)
        {
            animator.SetTrigger(attackAnimatorParameter);
        }
    }

    void StartMeleeAttack()
    {
        base.StartExecute();

        damageCollider.enabled = true;
    }

    void EndMeleeAttack()
    {
        base.FinishExecute();

        damageCollider.enabled = false;
    }
}
