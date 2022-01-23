using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NPCSystemRuntimeDataEditorWindow : EditorWindow
{
    public NPCSystemRuntimeData data;
    private NPCSystemRuntimeData dataCopy;
    private Vector2 scrollPosNPCs;
    private Vector2 scrollPosNPCTasks;
    public static void Open(NPCSystemRuntimeData data)
    {
        NPCSystemRuntimeDataEditorWindow window = GetWindow<NPCSystemRuntimeDataEditorWindow>("NPCSystemRuntimeData Editor");

        window.data = data;
        window.dataCopy = data.Copy();
    }
    private void OnGUI()
    {
        // Return if no Refrence
        if (data == null) return;

        // Set Title
        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));
        if (dataCopy.name != "")
        {
            titleContent.text = "NPCSystemRuntimeData Editor - " + dataCopy.name;
        }
        else
        {
            titleContent.text = "NPCSystemRuntimeData Editor - No Name";
        }
        // Use file name as title
        CustomEditorStyles.CenterdTitle(data.name);
        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        // Draw ScrollView to hold all the runtime NPCs
        GUILayout.Label("NPCs:", EditorStyles.boldLabel);
        scrollPosNPCs = GUILayout.BeginScrollView(scrollPosNPCs, false, true);
        foreach (NPCRuntimeBlueprint npc in dataCopy.npcs)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(npc.npc.name, GUILayout.Width(Screen.width / 5));
            EditorGUILayout.ObjectField(npc.npc, typeof(NPC), false, GUILayout.Width(Screen.width / 5 * 2.6f));
            if (GUILayout.Button("Edit", GUILayout.Width(Screen.width / 5)))
            {
                NPCEditorWindow.Open(npc.npc);
                GUIUtility.ExitGUI();
            }
            GUILayout.EndHorizontal();
            npc.mood = EditorGUILayout.FloatField("Mood", npc.mood);
        }
        GUILayout.EndScrollView();

        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));
        // Draw ScrollView to hold all the runtime Tasks
        GUILayout.Label("Tasks:", EditorStyles.boldLabel);
        scrollPosNPCTasks = GUILayout.BeginScrollView(scrollPosNPCTasks, false, true);
        foreach (NPCTaskRuntimeBlueprint task in dataCopy.tasks)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(task.task.name, GUILayout.Width(Screen.width / 5));
            EditorGUILayout.ObjectField(task.task, typeof(NPCTask), false, GUILayout.Width(Screen.width / 5 * 2.6f));
            if (GUILayout.Button("Edit", GUILayout.Width(Screen.width / 5)))
            {
                NPCTaskEditorWindow.Open(task.task);
                GUIUtility.ExitGUI();
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            task.isCompleted = EditorGUILayout.Toggle("Completed", task.isCompleted);
            task.completedSuccessfully = EditorGUILayout.Toggle("Successful", task.completedSuccessfully);
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();

        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        // Draw the Button to Open the Viewof The Dictonary
        if (GUILayout.Button("Show Dictonary"))
        {
            NPCSystemRuntimeDataEditorDictonaryWindow.Open(dataCopy);
            GUIUtility.ExitGUI();
        }
        if (GUILayout.Button("Generate Dictonary"))
        {
            dataCopy.GenerateDictonary();
        }

        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        // Draw Buttons to Recalculate the Dictionary and Moods
        if (GUILayout.Button("Recalculate Moods"))
        {

        }

        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        // Draw Save and Revert Buttons
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            GUI.FocusControl("");
            data.Copy(dataCopy);
            EditorUtility.SetDirty(data);
        }
        if (GUILayout.Button("Revert"))
        {
            GUI.FocusControl("");
            dataCopy.Copy(data);
        }
        GUILayout.EndHorizontal();
    }
}