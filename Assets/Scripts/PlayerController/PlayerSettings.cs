using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    [Header("Layers")]
    public LayerMask groundLayer;
    [Header("Ground Detection")]
    public float groundCheckRadius = 0.25f;

    [Header("Walking, Running, Sprinting")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float sprintSpeed = 15f;
    public float diferenceStraveSpeed = 0.5f;
    public float acceleration = 0.5f;
    public float deceleration = 0.5f;

    [Header("Crouching")]
    public float someSetting = 2f;

    [Header("Jumping")]
    public float jumpForce = 10f;
}
