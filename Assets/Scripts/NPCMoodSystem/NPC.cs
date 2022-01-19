using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/NPC", order = 1)]
public class NPC : ScriptableObject
{
    public string _name;
    [TextArea]
    public string description;
    private float mood { get; set; }
    public float moodGoal = 100f;
    public List<NPCTaskBlueprint> tasks = new List<NPCTaskBlueprint>();

    //Function to Recive the Callback that a Task has been Completed
    public void CompleteTask(NPCTask task, bool positiveSucess)
    {
        NPCTaskBlueprint taskBlueprint = tasks.Find(x => x.task == task);
        taskBlueprint.completed = true;
        taskBlueprint.failed = !positiveSucess;
        mood += positiveSucess ? taskBlueprint.positiveReward : taskBlueprint.negativeReward;
        Debug.Log("The Task: " + task._name + " has been Completed for the NPC: " + _name);
    }
    public void SubscribeToTasks()
    {
        tasks.ForEach(x => x.task.Subscribe(this));
    }
}
