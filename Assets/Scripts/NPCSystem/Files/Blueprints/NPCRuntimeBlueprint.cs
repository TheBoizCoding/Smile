using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCRuntimeBlueprint
{
    public NPC npc;
    public float mood;

    public NPCRuntimeBlueprint Copy()
    {
        NPCRuntimeBlueprint blueprint = new NPCRuntimeBlueprint();
        blueprint.npc = npc;
        blueprint.mood = mood;
        return blueprint;
    }
}
