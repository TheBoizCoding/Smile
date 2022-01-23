using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCTaskRuntimeBlueprint
{
    public NPCTask task;
    public bool isCompleted;
    public bool completedSuccessfully;

    public NPCTaskRuntimeBlueprint Copy()
    {
        NPCTaskRuntimeBlueprint blueprint = new NPCTaskRuntimeBlueprint();
        blueprint.task = task;
        blueprint.isCompleted = isCompleted;
        blueprint.completedSuccessfully = completedSuccessfully;
        return blueprint;
    }
}
