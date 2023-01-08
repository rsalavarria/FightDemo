using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    public float speed;
    public int distance;
    
    readonly float durationTime = 1;
    float currentTime;

    bool isExecuting;

    [Header("Animation Parameters")]
    public string animatorParameter;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Execute();
        }

        if (isExecuting)
        {
            Dashing();
        }

        if (currentTime >= (durationTime / speed))
        {
            Stop();
        }
    }

    void Dashing()
    {
        currentTime += Time.deltaTime;
        Vector3 direction = transform.forward * distance;
        characterController.Move(direction * Time.deltaTime * speed);
    }

    void Execute()
    {
        //animator.SetTrigger(animatorParameter);
        isExecuting = true;
    }

    void Stop()
    {
        isExecuting = false;
        currentTime = 0;
    }
}
