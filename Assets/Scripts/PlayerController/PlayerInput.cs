using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Variables
    public float X;
    public bool jumpDown;
    public bool jumpUp;

    // Input Callbacks
    public void OnMoveX(InputAction.CallbackContext context)
    {
        X = context.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        jumpUp = context.phase == InputActionPhase.Canceled && jumpDown;
        jumpDown = context.phase == InputActionPhase.Started;
    }

}
