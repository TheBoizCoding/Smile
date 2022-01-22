using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NPCTaskEditorWindow : EditorWindow
{
    public NPCTask npcTask;
    private NPCTask npcTaskCopy;
    public static void Open(NPCTask npcTask)
    {
        NPCTaskEditorWindow window = GetWindow<NPCTaskEditorWindow>("NPC Task Editor");
        window.minSize = new Vector2(150, 300);
        window.maxSize = new Vector2(150, 300);

        window.npcTask = npcTask;
        window.npcTaskCopy = npcTask.Copy();

    }

    private void OnGUI()
    {
        // Return if no Refrence
        if (npcTaskCopy == null) return;

        // Set Title
        if (npcTaskCopy._name != "")
        {
            titleContent.text = npcTaskCopy._name;
        }
        else
        {
            titleContent.text = "NPC Task Editor";
        }

        // Draw Textfield to change the Task Name
        GUILayout.Label("Name:");
        npcTaskCopy._name = EditorGUILayout.TextField(npcTaskCopy._name);

        // Draw TextArea to change the Task Description
        GUILayout.Label("Description:");
        npcTaskCopy.description = EditorGUILayout.TextArea(npcTaskCopy.description, GUILayout.Height(185));

        //2 buttons aside, one for save and one for revert in the botoom center
        GUILayout.BeginArea(new Rect(0, position.height - 50, position.width, 50));
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            GUI.FocusControl("");
            npcTask.Copy(npcTaskCopy);
            EditorUtility.SetDirty(npcTask);
        }
        if (GUILayout.Button("Revert"))
        {
            GUI.FocusControl("");
            npcTaskCopy.Copy(npcTask);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}