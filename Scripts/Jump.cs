using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability
{
    Animator animator;
    CharacterController characterController;

    public float jumpSpeed;
    public int jumpDistance;

    [Header("Animation Parameters")]
    public string jumpAnimatorParameter;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {

        if (isExecuting)
        {
            Jumping();
        }
    }

    public void Prepare()
    {
        animator.SetTrigger(jumpAnimatorParameter);
    }

    void Jumping()
    {
        currentTime += Time.deltaTime;
        Vector3 direction = transform.up * jumpDistance;
        characterController.Move(direction * Time.deltaTime * jumpSpeed);
    }

    void StartJump()
    {
        base.StartExecute();
    }

    void EndJump()
    {
        base.FinishExecute();
    }
}
