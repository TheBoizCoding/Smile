using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCTaskBlueprint
{
    public NPCTask task;
    public bool completed;
    public bool failed;
    public float positiveReward;
    public float negativeReward;

}
