using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "NPC/Task", order = 1)]
public class NPCTask : ScriptableObject
{
    public string _name;
    [TextArea] public string description;

    public NPCTask Copy()
    {
        return (NPCTask)this.MemberwiseClone();
    }
    public void Copy(NPCTask npcTask)
    {
        this._name = npcTask._name;
        this.description = npcTask.description;
    }
}