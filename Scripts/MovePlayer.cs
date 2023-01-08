using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    public float moveSpeed = 10;
    public float rotationSpeed = 20;
    public float groundCheckRadius = .5f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Transform cameraTransform;

    float turnSmoothVelocity;
    float originalStepOffset;
    float ySpeed;

    [Header("Animation Parameters")]
    public string groundedParameter;
    public string moveParameter;
    public string jumpParameter;
    public string doubleJumpParameter;

    bool jumping;
    bool doubleJumping;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        originalStepOffset = characterController.stepOffset;
    }

    private void Update()
    {
        if (GroundDetected())
            animator.SetBool(groundedParameter, true);
        else if (!characterController.isGrounded)
            animator.SetBool(groundedParameter, false);
    }

    public void Move(Vector3 moveDirection)
    {
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);

        float speed = inputMagnitude * moveSpeed;

        Vector3 movementDirection = Vector3.zero;

        if (moveDirection.magnitude != 0)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, .1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            movementDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward * moveDirection.magnitude;
        }


        Vector3 velocity = movementDirection * speed;
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (characterController.isGrounded)
        {
            jumping = doubleJumping = false;
            animator.ResetTrigger(jumpParameter);
            animator.ResetTrigger(doubleJumpParameter);
            //characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                ySpeed = 6;
                jumping = true;
                animator.SetTrigger(jumpParameter);
            }
        }
        else //if (!GroundDetected() || !characterController.isGrounded)
        {
            //characterController.stepOffset = 0;
            if (Input.GetKeyDown(KeyCode.Space) && jumping && !doubleJumping)
            {
                ySpeed = 13;
                jumping = doubleJumping = true;
                animator.SetTrigger(doubleJumpParameter);
            }
        }

        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        animator.SetFloat(moveParameter, movementDirection.magnitude);


    }

    bool GroundDetected()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
