using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Manual Refrences
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform groundCheckPosition;
    //Automatic Refrences
    private Rigidbody rb;
    //Variables to Store some InputValues
    private bool Walking = false;
    private bool Sprinting = false;
    private bool Crouching = false;
    private Vector2 moveDirInput;
    private Vector2 lookDirDeltaInput;

    //Awake
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("PlayerController: Rigidbody not found!");
        }
    }
    //Update
    private void Update()
    {

    }
    //Input Callbacks
    public void onLook(InputAction.CallbackContext context)
    {
        lookDirDeltaInput = context.ReadValue<Vector2>();
    }
    public void onMove(InputAction.CallbackContext context)
    {
        moveDirInput = context.ReadValue<Vector2>();
    }
    public void onWalk(InputAction.CallbackContext context)
    {
        Walking = context.ReadValueAsButton();
    }
    public void onSprint(InputAction.CallbackContext context)
    {
        Sprinting = context.ReadValueAsButton();
    }
    public void onJump(InputAction.CallbackContext context)
    {

    }
    public void onCrouch(InputAction.CallbackContext context)
    {
        Crouching = context.ReadValueAsButton();
    }
    //Function to Test the Ground
    private bool isGrounded()
    {
        return Physics.CheckSphere(groundCheckPosition.position, playerSettings.groundCheckRadius, playerSettings.groundLayer);
    }
    //Function to  Draw some Debug Lines
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPosition.position, playerSettings.groundCheckRadius);
    }
}
