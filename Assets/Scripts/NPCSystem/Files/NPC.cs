using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/NPC", order = 1)]
public class NPC : ScriptableObject
{
    public string _mame;
    [TextArea] public string description;
}