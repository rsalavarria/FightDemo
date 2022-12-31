using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Animator animator;
    public int health;

    public bool animateDamage;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(animateDamage)
            animator.SetTrigger("Hit");
    }
}
