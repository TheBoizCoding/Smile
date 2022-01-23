using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class NPCTaskAssetHandler
{
    [OnOpenAsset]
    public static bool OpenEditor(int instanceID, int line)
    {
        NPCTask task = EditorUtility.InstanceIDToObject(instanceID) as NPCTask;
        if (task != null)
        {
            NPCTaskEditorWindow.Open(task);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(NPCTask))]
public class NPCTaskEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open NPCTask Editor"))
        {
            NPCTaskEditorWindow.Open(target as NPCTask);
        }
    }
}