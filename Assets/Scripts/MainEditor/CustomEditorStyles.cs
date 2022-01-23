using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomEditorStyles
{
    public static void HorizontalLine(Color color)
    {
        GUIStyle horizontalLine = new GUIStyle();
        horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
        horizontalLine.margin = new RectOffset(5, 5, 4, 4);
        horizontalLine.fixedHeight = 2;
        var c = GUI.color;
        GUI.color = color;
        GUILayout.Space(2);
        GUILayout.Box(GUIContent.none, horizontalLine);
        GUILayout.Space(2);
        GUI.color = c;
    }
    public static void Title(string titleText)
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 20;
        //give it the default text color
        titleStyle.normal.textColor = GUI.skin.label.normal.textColor;
        //give it a little  bit of space on the left side
        titleStyle.margin = new RectOffset(5, 5, 5, 5);
        GUILayout.Label(titleText, titleStyle);
    }
    public static void Title(string titleText, Color color)
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 20;
        //give it the default text color
        titleStyle.normal.textColor = color;
        //give it a little  bit of space on the left side
        titleStyle.margin = new RectOffset(5, 5, 5, 5);
        GUILayout.Label(titleText, titleStyle);
    }
    public static void CenterdTitle(string titleText)
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 20;
        //give it the default text color
        titleStyle.normal.textColor = GUI.skin.label.normal.textColor;
        //Center the text
        titleStyle.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label(titleText, titleStyle);
    }
    public static void CenterdTitle(string titleText, Color color)
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 20;
        //give it the default text color
        titleStyle.normal.textColor = color;
        //Center the text
        titleStyle.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label(titleText, titleStyle);
    }
}