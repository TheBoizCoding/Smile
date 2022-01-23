using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/Settings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float speed = 5f;
}
