using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NPCEditorWindow : EditorWindow
{
    public NPC npc;
    private NPC npcCopy;
    private Vector2 scrollPos;
    public static void Open(NPC npc)
    {
        NPCEditorWindow window = GetWindow<NPCEditorWindow>("NPC Editor");
        window.minSize = new Vector2(350, 600);
        window.maxSize = new Vector2(350, 600);

        window.npc = npc;
        window.npcCopy = npc.Copy();
    }

    private void OnGUI()
    {
        // Return if no Refrence
        if (npcCopy == null) return;

        // Set Title
        if (npcCopy._name != "")
        {
            titleContent.text = "NPC Editor - " + npcCopy._name;
        }
        else
        {
            titleContent.text = "NPC Editor - No Name";
        }

        // Draw Textfield to change the NPC Name
        npcCopy._name = EditorGUILayout.TextField("Name:", npcCopy._name);

        // Draw TextArea to change the NPC Description
        npcCopy.description = EditorGUILayout.TextArea(npcCopy.description, GUILayout.Height(60));

        // Draw The NPC Mood Goal
        npcCopy.moodGoal = EditorGUILayout.FloatField("Mood Goal:", npcCopy.moodGoal);

        // Draw a Container that will hold the NPC Tasks and is scrollable
        GUILayout.BeginVertical("box");
        GUILayout.Label("Tasks:", EditorStyles.boldLabel);
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Height(250));
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
        GUILayout.EndVertical();

        // Draw a Button to add a new Task
        if (GUILayout.Button("Add Task"))
        {
            npcCopy.tasks.Add(new NPCTaskBlueprint());
        }

        //2 buttons aside, one for save and one for revert in the botoom center
        GUILayout.BeginArea(new Rect(0, position.height - 50, position.width, 50));
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            GUI.FocusControl("");
            npc.Copy(npcCopy);
        }
        if (GUILayout.Button("Revert"))
        {
            GUI.FocusControl("");
            npcCopy.Copy(npc);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}