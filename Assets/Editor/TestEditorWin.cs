using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestEditorWin : EditorWindow
{
    [MenuItem("Window/Game Setting Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TestEditorWin));
    }

    void OnGUI()
    {
        GUILayout.Label("Game Setting", EditorStyles.boldLabel);
    }
}
