using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/NPC", order = 1)]
public class NPC : ScriptableObject
{
    public string _name;
    [TextArea] public string description;
    public float moodGoal;
    public List<NPCTaskBlueprint> tasks;

    public NPC Copy()
    {
        return (NPC)this.MemberwiseClone();
    }
    public void Copy(NPC npc)
    {
        this._name = npc._name;
        this.description = npc.description;
    }
}