using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCTask", menuName = "NPC/Task", order = 1)]
public class NPCTask : ScriptableObject
{
    public string _name;
    [TextArea]
    public string description;
    //List to Store the NPCs that subscribed to this Task
    private List<NPC> subscribers = new List<NPC>();
    //Function to Subscribe adn Usubsribe a NPC to this Task
    public void Subscribe(NPC npc)
    {
        subscribers.Add(npc);
    }
    public void Unsubscribe(NPC npc)
    {
        subscribers.Remove(npc);
    }
    public void ClearSubscribers()
    {
        subscribers.Clear();
    }
    //Public Function to Complete the Task
    public void Complete(bool positiveSucess)
    {
        //Loop through all the Subscribers
        foreach (NPC npc in subscribers)
        {
            //Call the CompleteTask Function on each of them
            npc.CompleteTask(this, positiveSucess);
        }
    }

}
