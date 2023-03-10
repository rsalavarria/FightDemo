using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;
    PlayerController playerController;

    public float speed;
    public int distance;

    readonly float durationTime = 1;
    float currentTime;

    float ySpeed;

    bool isExecuting;

    [Header("Animation Parameters")]
    public string jumpParameter;
    public string doubleJumpParameter;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!playerController.isFalling)
                Execute();
            else
                ExecuteDouble();
        }

        if (isExecuting)
        {
            Jumping();
        }

        if (currentTime >= (durationTime / speed))
        {
            Stop();
        }
    }

    void Jumping()
    {
        currentTime += Time.deltaTime;
        Vector3 direction = transform.up * distance;
        characterController.Move(direction * Time.deltaTime * speed);
    }

    void Execute()
    {
        animator.SetTrigger(jumpParameter);
        isExecuting = true;
    }

    void ExecuteDouble()
    {
        animator.SetTrigger(doubleJumpParameter);
        isExecuting = true;
    }

    void Stop()
    {
        isExecuting = false;
        currentTime = 0;
    }
}
