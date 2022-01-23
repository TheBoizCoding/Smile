using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class NPCSystemRuntimeDataAssetHandler
{
    [OnOpenAsset]
    public static bool OpenEditor(int instanceID, int line)
    {
        NPCSystemRuntimeData data = EditorUtility.InstanceIDToObject(instanceID) as NPCSystemRuntimeData;
        if (data != null)
        {
            NPCSystemRuntimeDataEditorWindow.Open(data);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(NPCSystemRuntimeData))]
public class NPCSystemRuntimeDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open NPCSystemRuntimeData Editor"))
        {
            NPCSystemRuntimeDataEditorWindow.Open(target as NPCSystemRuntimeData);
        }
    }
}