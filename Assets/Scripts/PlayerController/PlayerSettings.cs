using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    [Header("Walking and Running")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
}
