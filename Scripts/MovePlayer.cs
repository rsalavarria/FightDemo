using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    public Transform cam;

    public float moveSpeed = 5;

    float turnSmoothVelocity;

    int isBlendHash;

    private void Awake()
    {
        isBlendHash = Animator.StringToHash("Blend");
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (move.magnitude != 0)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, .1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            characterController.Move(moveDir * moveSpeed * Time.deltaTime);
        }

        HandleMoveAnimation(move);
    }

    void HandleMoveAnimation(Vector3 currentMovement)
    {
        Vector3 xzMovement = new Vector3(currentMovement.x, 0, currentMovement.z);

        animator.SetFloat(isBlendHash, xzMovement.magnitude);
    }
}
