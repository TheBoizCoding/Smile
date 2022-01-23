using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NPCEditorWindow : EditorWindow
{
    public NPC npc;
    private NPC npcCopy;
    private List<NPCTaskBlueprint> tasksCopy;
    private Vector2 scrollPos;
    public static void Open(NPC npc)
    {
        NPCEditorWindow window = GetWindow<NPCEditorWindow>("NPC Editor");

        window.npc = npc;
        window.npcCopy = npc.Copy();
        window.tasksCopy = new List<NPCTaskBlueprint>();
        foreach (NPCTaskBlueprint task in npc.tasks)
        {
            window.tasksCopy.Add(task.Copy());
        }
        window.npcCopy.tasks = window.tasksCopy;
    }

    private void OnGUI()
    {
        // Return if no Refrence
        if (npc == null) return;

        // Set Title
        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));
        if (npcCopy._name != "")
        {
            titleContent.text = "NPC Editor - " + npcCopy._name;
            CustomEditorStyles.CenterdTitle(npcCopy._name);
        }
        else
        {
            titleContent.text = "NPC Editor - No Name";
            CustomEditorStyles.CenterdTitle("No Name");
        }
        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        // Draw Textfield to change the NPC Name
        npcCopy._name = EditorGUILayout.TextField("Name:", npcCopy._name);

        // Draw TextArea to change the NPC Description
        GUILayout.Label("Description:");
        npcCopy.description = EditorGUILayout.TextArea(npcCopy.description, GUILayout.Height(60));

        // Draw The NPC Mood Goal
        npcCopy.moodGoal = EditorGUILayout.FloatField("Mood Goal:", npcCopy.moodGoal);

        // draw  a horizontal line sepperator
        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        // Draw a Container that will hold the NPC Tasks and is scrollable and fills the rest of the window
        GUILayout.Label("Tasks:", EditorStyles.boldLabel);
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
        for (int i = 0; i < npcCopy.tasks.Count; i++)
        {
            GUILayout.Label(npcCopy.tasks[i].task is null ? "No Name:" : npcCopy.tasks[i].task._name is "" ? "No Name:" : npcCopy.tasks[i].task._name);
            npcCopy.tasks[i].task = (NPCTask)EditorGUILayout.ObjectField(npcCopy.tasks[i].task, typeof(NPCTask), false);
            npcCopy.tasks[i].positiveReward = EditorGUILayout.FloatField("Positive Reward:", npcCopy.tasks[i].positiveReward);
            npcCopy.tasks[i].negativeReward = EditorGUILayout.FloatField("Negative Reward:", npcCopy.tasks[i].negativeReward);
            GUILayout.BeginHorizontal();
            if (npcCopy.tasks[i].task != null)
            {
                if (GUILayout.Button("Edit"))
                {
                    NPCTaskEditorWindow.Open(npcCopy.tasks[i].task);
                    GUIUtility.ExitGUI();
                }
            }
            else
            {
                //Draw Edit button, but deactivated
                GUI.enabled = false;
                if (GUILayout.Button("Edit"))
                {

                }
            }
            GUI.enabled = true;

            if (GUILayout.Button("Duplicate"))
            {
                npcCopy.tasks.Add(npcCopy.tasks[i].Copy());
            }
            if (GUILayout.Button("Remove"))
            {
                npcCopy.tasks.RemoveAt(i);
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
        GUILayout.Space(10);
        // Draw a Button to add a new Task
        if (GUILayout.Button("Add Task"))
        {
            npcCopy.tasks.Add(new NPCTaskBlueprint());
        }

        // draw  a horizontal line sepperator
        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        //2 buttons aside, one for save and one for revert in the botoom center
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            GUI.FocusControl("");
            npc.Copy(npcCopy);
            npc.tasks = new List<NPCTaskBlueprint>();
            foreach (NPCTaskBlueprint task in npcCopy.tasks)
            {
                npc.tasks.Add(task.Copy());
            }
            EditorUtility.SetDirty(npc);
        }
        if (GUILayout.Button("Revert"))
        {
            GUI.FocusControl("");
            npcCopy.Copy(npc);
            tasksCopy = new List<NPCTaskBlueprint>();
            foreach (NPCTaskBlueprint task in npc.tasks)
            {
                tasksCopy.Add(task.Copy());
            }
            npcCopy.tasks = tasksCopy;
        }
        GUILayout.EndHorizontal();
    }
}