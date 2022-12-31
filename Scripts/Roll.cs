using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : Ability
{
    CharacterController characterController;
    Animator animator;

    public float speed;
    public float durationTime;
    public int rollDistance;

    [Header("Animation Parameters")]
    public string rollAnimatorParameter = "Roll";

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isExecuting)
        {
            Rolling();
        }

        if (currentTime >= durationTime)
        {
            EndRoll();
        }
    }

    public void Prepare()
    {
        animator.SetTrigger(rollAnimatorParameter);
        StartRoll();
    }

    void Rolling()
    {
        currentTime += Time.deltaTime;
        Vector3 direction = transform.forward * rollDistance;
        characterController.Move(direction * Time.deltaTime * speed);
    }

    void StartRoll()
    {
        base.StartExecute();
    }
    void EndRoll()
    {
        base.FinishExecute();
    }
}
