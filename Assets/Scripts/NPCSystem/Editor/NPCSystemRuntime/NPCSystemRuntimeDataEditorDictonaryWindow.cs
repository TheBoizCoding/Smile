using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NPCSystemRuntimeDataEditorDictonaryWindow : EditorWindow
{
    public NPCSystemRuntimeData data;
    public Vector2 ScrollViewPos;
    public Dictionary<NPCTask, bool> dictonaryFoldoutActive = new Dictionary<NPCTask, bool>();
    public static void Open(NPCSystemRuntimeData data)
    {
        NPCSystemRuntimeDataEditorDictonaryWindow window = GetWindow<NPCSystemRuntimeDataEditorDictonaryWindow>("NPCSystemRuntimeData Dictonary");

        window.data = data;
    }
    private void OnGUI()
    {
        // Return if no Refrence
        if (data == null) return;
        // Draw a button to Generate the Dictionary
        if (GUILayout.Button("Generate Dictionary"))
        {
            data.GenerateDictonary();
        }
        CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));

        if (data.taskToNPCDictonary == null) return;

        // Draw The whole Dictionary in a Scrollview, but only if its not empty
        GUILayout.Label("Dictionary:", EditorStyles.boldLabel);
        if (data.taskToNPCDictonary.Count > 0)
        {
            ScrollViewPos = GUILayout.BeginScrollView(ScrollViewPos, false, true);
            // Draw a Foldout for each Task
            foreach (NPCTask task in data.taskToNPCDictonary.Keys)
            {
                // Create the Foldout
                if (dictonaryFoldoutActive.ContainsKey(task))
                {
                    dictonaryFoldoutActive[task] = EditorGUILayout.Foldout(dictonaryFoldoutActive[task], task.name);
                }
                else
                {
                    dictonaryFoldoutActive.Add(task, EditorGUILayout.Foldout(false, task.name));
                }
                // If the Foldout is active
                if (dictonaryFoldoutActive[task])
                {
                    // Draw each NPC in the Task
                    foreach (NPCRuntimeBlueprint npc in data.taskToNPCDictonary[task])
                    {
                        GUILayout.BeginHorizontal();
                        // Draw the NPC Name
                        GUILayout.Label(npc.npc.name, GUILayout.Width(Screen.width / 3f));
                        EditorGUILayout.ObjectField(npc.npc, typeof(NPC), false);
                        GUILayout.EndHorizontal();
                    }
                }
                // Draw a Horizontal Line
                CustomEditorStyles.HorizontalLine(new Color(0.3f, 0.3f, 0.3f));
            }
            GUILayout.EndScrollView();
        }
    }
}
