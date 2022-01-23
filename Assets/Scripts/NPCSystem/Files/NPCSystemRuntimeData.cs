using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeData", menuName = "NPC/RuntimeData", order = 2)]
public class NPCSystemRuntimeData : ScriptableObject
{
    public List<NPCRuntimeBlueprint> npcs;
    public List<NPCTaskRuntimeBlueprint> tasks;
    public Dictionary<NPCTask, List<NPCRuntimeBlueprint>> taskToNPCDictonary;

    public void GenerateDictonary()
    {
        taskToNPCDictonary = new Dictionary<NPCTask, List<NPCRuntimeBlueprint>>();
        foreach (NPCRuntimeBlueprint npc in npcs)
        {
            foreach (NPCTaskRuntimeBlueprint task in tasks)
            {
                foreach (NPCTaskBlueprint blueprint in npc.npc.tasks)
                {
                    if (task.task == blueprint.task)
                    {
                        if (!taskToNPCDictonary.ContainsKey(task.task))
                        {
                            List<NPCRuntimeBlueprint> batch = new List<NPCRuntimeBlueprint>();
                            batch.Add(npc);
                            taskToNPCDictonary.Add(task.task, batch);
                        }
                        else
                        {
                            List<NPCRuntimeBlueprint> batch = taskToNPCDictonary[task.task];
                            batch.Add(npc);
                            taskToNPCDictonary[task.task] = batch;
                        }
                    }
                }
            }
        }
    }
    public void RecalculateMood()
    {
        foreach (NPCRuntimeBlueprint npc in npcs)
        {
            npc.mood = 0;
        }
        foreach (NPCTaskRuntimeBlueprint task in tasks)
        {
            if (!task.isCompleted) continue;
            foreach (NPCRuntimeBlueprint npc in taskToNPCDictonary[task.task])
            {
                NPCTaskBlueprint blueprint = npc.npc.tasks.Find(x => x.task == task.task);
                npc.mood += task.completedSuccessfully ? blueprint.positiveReward : blueprint.negativeReward;
            }
        }
    }
    public bool isNPCHappy(NPCRuntimeBlueprint npc)
    {
        return npc.mood >= npc.npc.moodGoal;
    }

    public NPCSystemRuntimeData Copy()
    {
        NPCSystemRuntimeData data = CreateInstance<NPCSystemRuntimeData>();
        data.npcs = new List<NPCRuntimeBlueprint>();
        data.tasks = new List<NPCTaskRuntimeBlueprint>();
        foreach (NPCRuntimeBlueprint npc in npcs)
        {
            data.npcs.Add(npc.Copy());
        }
        foreach (NPCTaskRuntimeBlueprint task in tasks)
        {
            data.tasks.Add(task.Copy());
        }
        return data;
    }
    public void Copy(NPCSystemRuntimeData data)
    {
        this.npcs = data.npcs;
        this.tasks = data.tasks;
        taskToNPCDictonary = data.taskToNPCDictonary;
    }
}