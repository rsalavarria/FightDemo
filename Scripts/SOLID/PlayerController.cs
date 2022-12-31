using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    PlayerMove playerMove;
    Jump jump;
    Roll roll;
    MeleeAttack meleeAttack;
    Animator animator;

    [HideInInspector]
    public bool isFalling;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerMove = GetComponent<PlayerMove>();
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

        Vector3 moveInput = new Vector3(horizontalInput, 0, verticalInput).normalized;
        playerMove.Move(moveInput);

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

        if (InputManager.instance.GetJumpInput())
        {
            jump.Prepare();
        }

        if (InputManager.instance.GetMeleeAttackInput())
        {
            meleeAttack.Prepare();
        }

        if (InputManager.instance.GetRollInput())
        {
            roll.Prepare();
        }
    }
}
