using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class AssetHandler
{
    [OnOpenAsset]
    public static bool OpenEditor(int instanceID, int line)
    {
        NPC npc = EditorUtility.InstanceIDToObject(instanceID) as NPC;
        if (npc != null)
        {
            NPCEditorWindow.Open(npc);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(NPC))]
public class NPCEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open NPC Editor"))
        {
            NPCEditorWindow.Open(target as NPC);
        }
    }
}