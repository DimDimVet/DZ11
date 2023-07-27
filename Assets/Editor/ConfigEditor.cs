using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ConfigEditor : EditorWindow
{
    private SerializedProperty healtPlayer;//������ �� ����
    private SerializedProperty shootCount;//������ �� ����
    private string[] playerList;

    [MenuItem("DZ11/Menu Config")]//��������� � ���� Window ������ Game Setting Window
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConfigEditor));//GetWindow ��������� ���� 
    }

    void OnGUI()
    {
        playerList = AssetDatabase.FindAssets("Statistic");//������ ������� � ������� settings

        GUILayout.Label("Set Mode", EditorStyles.boldLabel);//��� ���������� � ����
        foreach (var item in playerList)//������� ��������� ������ � ����� � �������
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//������� ��� ���������
        }

    }
}
