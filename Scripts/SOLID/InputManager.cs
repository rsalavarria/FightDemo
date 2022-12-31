using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public float GetHorizontalAxisValue()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetVerticalAxisValue()
    {
        return Input.GetAxis("Vertical");
    }

    public bool GetCameraInput()
    {
        return Input.GetMouseButton(1);
    }

    public bool GetJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public bool GetMeleeAttackInput()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool GetRollInput()
    {
        return Input.GetKeyDown("q");
    }
}
