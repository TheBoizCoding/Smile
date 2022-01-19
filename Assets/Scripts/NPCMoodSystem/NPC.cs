using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC/NPC", order = 1)]
public class NPC : ScriptableObject
{
    public string _name;
    [TextArea]
    public string description;
    public List<NPCTaskBlueprint> tasks = new List<NPCTaskBlueprint>();

    //Function to Recive the Callback that a Task has been Completed
    public void CompleteTask(NPCTask task, bool positiveSucess)
    {
        Debug.Log("The Task: " + task._name + " has been Completed for the NPC: " + _name);
    }
}
