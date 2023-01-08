using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    PlayerMove playerMove;
    MovePlayer movePlayer;
    Jump jump;
    Roll roll;
    MeleeAttack meleeAttack;
    Animator animator;

    public Transform target;

    //[HideInInspector]
    public bool isFalling;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerMove = GetComponent<PlayerMove>();
        movePlayer = GetComponent<MovePlayer>();
        jump = GetComponent<Jump>();
        roll = GetComponent<Roll>();
        meleeAttack = GetComponent<MeleeAttack>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //animator.SetBool("Grounded", characterController.isGrounded);
        float horizontalInput = InputManager.instance.GetHorizontalAxisValue();
        float verticalInput = InputManager.instance.GetVerticalAxisValue();

        Vector3 moveInput = new Vector3(horizontalInput, 0, verticalInput);
        movePlayer.Move(moveInput);

        //animator.SetFloat("Blend", moveInput.magnitude);


        if (!characterController.isGrounded)
        {
            isFalling = true;
        }

        if (isFalling)
        {
            if (characterController.isGrounded)
            {
                isFalling = false;
            }
        }
    }
}
