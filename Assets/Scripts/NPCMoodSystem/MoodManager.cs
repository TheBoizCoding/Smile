using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodManager : MonoBehaviour
{
    public List<NPC> npcs = new List<NPC>();

    public void Awake()
    {
        npcs.ForEach(x => x.SubscribeToTasks());
    }
    public void OnApplicationQuit()
    {
        npcs.ForEach(x => x.tasks.ForEach(y => y.task.ClearSubscribers()));
    }
}
