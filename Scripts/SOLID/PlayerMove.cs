using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    public float moveSpeed = 5;
    public float rotationSpeed = 5;
    public Transform cameraTransform;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    float turnSmoothVelocity;

    [Header("Animation Parameters")]
    public string groundAnimatorParameter;
    public string moveAnimatorParameter;

    float ySpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (GroundDetected())
            animator.SetBool(groundAnimatorParameter, true);
        else if(!characterController.isGrounded)
            animator.SetBool(groundAnimatorParameter, false);
    }

    public void Move(Vector3 moveInput)
    {
        /*Vector3 direction = moveInput * moveSpeed * Time.deltaTime;

        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;

        if (direction != Vector3.zero)
        {
            Quaternion rotateTo = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotationSpeed * Time.deltaTime);
        }*/

        Vector3 moveDirection = Vector3.zero;

        if (moveInput.magnitude != 0)
        {
            float targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, .1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward * moveInput.magnitude;
        }

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
                ySpeed = 3;

        }

        moveDirection.y = ySpeed;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);


        animator.SetFloat(moveAnimatorParameter, moveInput.magnitude);


    }

    bool GroundDetected()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    /*public void Move(Vector3 movementDirection)
    {
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        float speed = inputMagnitude * moveSpeed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();


        Vector3 velocity = movementDirection * speed;
        ySpeed += Physics.gravity.y * Time.deltaTime * 4f;
        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
        }
        else
        {
            characterController.stepOffset = 0;
        }

        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        animator.SetFloat(moveAnimatorParameter, movementDirection.magnitude);


    }

    private Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        var ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f))
        {
            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedVelocity = slopeRotation * velocity;

            if (adjustedVelocity.y < 0)
            {
                return adjustedVelocity;
            }
        }
        return velocity;
    }*/
}
