using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    Animator animator;
    public Camera cam;
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 30;

    public GameObject muzzleVFX;
    GameObject muzzle;

    bool spelling;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !spelling)
        {
            muzzle = Instantiate(muzzleVFX, firePoint.position, Quaternion.identity, firePoint);
            animator.SetTrigger("Spell");
        }
    }

    void StartSpell()
    {
        spelling = true;
        Destroy(muzzle);
        InstantiateProjectile();
    }

    void EndSpell()
    {
        spelling = false;
    }

    void InstantiateProjectile()
    {
        Instantiate(projectile, firePoint.position, transform.rotation);
    }
}
