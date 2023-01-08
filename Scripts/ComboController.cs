using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboController : MonoBehaviour
{
    public static ComboController instance;
    Animator animator;

    //[HideInInspector]
    public bool canReceiveInput = true;
    //[HideInInspector]
    public bool inputReceived;

    public string[] attacks;
    public int attackIndex;

    public Collider swordDamage;

    CharacterController characterController;
    PlayerController playerController;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canReceiveInput)
        {
            //animator.SetBool("Slash1", true);
            inputReceived = true;
            //characterController.Move(playerController.target.position);
            //animator.SetTrigger(attacks[attackIndex]);
        }
    }

    public void ResetCombo()
    {
        attackIndex = 0;
    }

    public void ActiveDamageSword()
    {
        swordDamage.gameObject.SetActive(true);
    }
    
    public void DeactiveDamageSword()
    {
        swordDamage.gameObject.SetActive(false);
    }
}
