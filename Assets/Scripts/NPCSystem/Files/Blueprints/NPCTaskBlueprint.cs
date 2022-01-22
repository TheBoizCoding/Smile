using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCTaskBlueprint
{
    public NPCTask task;
    public float positiveReward;
    public float negativeReward;

    public NPCTaskBlueprint Copy()
    {
        return (NPCTaskBlueprint)this.MemberwiseClone();
    }

}
