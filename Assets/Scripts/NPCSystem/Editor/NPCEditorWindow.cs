using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NPCEditorWindow : EditorWindow
{
    public NPC npc;
    public static void Open(NPC npc)
    {
        NPCEditorWindow window = GetWindow<NPCEditorWindow>("NPC Editor");
        window.npc = npc;
    }

    private void OnGUI()
    {
        if (npc == null) return;
        GUILayout.Label(npc._mame, EditorStyles.boldLabel);
    }
}