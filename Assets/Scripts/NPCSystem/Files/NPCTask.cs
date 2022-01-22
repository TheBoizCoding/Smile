using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "NPC/Task", order = 1)]
public class NPCTask : ScriptableObject
{
    public string _mame;
    [TextArea] public string description;
}