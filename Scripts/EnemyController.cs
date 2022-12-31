using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    public Transform player;

    public float moveSpeed = 3;

    public float chaseDistance = 10;
    public float attackDistance = 2;

    public GameObject weapon;

    float distance;

    [SerializeField] State enemyState;

    enum State
    {
        Idle,
        Chase,
        Attack
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        if (enemyState != State.Attack)
        {
            if (distance <= chaseDistance)
            {
                enemyState = State.Chase;
            }
            else
            {
                enemyState = State.Idle;
            }
            var rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 6);
            //transform.LookAt(player.position, Vector3.up);
        }

        if (enemyState == State.Idle) {
            animator.SetBool("Chasing", false);
        }
    }

    void FixedUpdate()
    {
        if (enemyState == State.Chase)
        {
            if (distance <= attackDistance)
            {
                enemyState = State.Attack;
                animator.SetBool("Attacking", true);
                animator.SetBool("Chasing", false);
            }
            else
            {
                Chase();
            }
        }
    }

    void Chase()
    {
        animator.SetBool("Chasing", true);
        rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
    }

    void StartAttack()
    {
        weapon.SetActive(true);
    }

    void EndAttack()
    {
        weapon.SetActive(false);
        animator.SetBool("Attacking", false);
        enemyState = State.Idle;
    }
}
