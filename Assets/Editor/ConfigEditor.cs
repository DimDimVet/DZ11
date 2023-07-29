using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//[CustomEditor(typeof(Statistic))]
public class ConfigEditor : EditorWindow
{
    private string settings = "t:SettingsLoadData";
    private SettingsLoadData settingsFile;
    public bool isFireBase = false;
    public bool isLocalBase = false;
    public bool isDefault = false;

    private string[] settingsList;
    private bool buttonPress;

    [MenuItem("DZ11/Menu Config")]//��������� � ���� Window ������ Game Setting Window

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConfigEditor));//GetWindow ��������� ���� 
    }

    void OnGUI()
    {
        settingsList = AssetDatabase.FindAssets("t:settingsLoadData");//������ ������� � ������� settings
        //
        isFireBase = EditorGUILayout.Toggle("Fire Base", isFireBase);
        isLocalBase = EditorGUILayout.Toggle("Local Base", isLocalBase);
        isDefault = EditorGUILayout.Toggle("Default", isDefault);
        //
        GUILayout.Label("Connect Settings:", EditorStyles.boldLabel);//��� ���������� � ����
        foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//������� ��� ���������
            GUILayout.Space(10);//������� ������ � ��������
 
        }

        buttonPress = GUILayout.Button("BBBBB");
        if (buttonPress)
        {
            foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//�� �������� ��������, ������� ������ � ���������� ��������
                isFireBase = settingsFile.isFireBase;
                isLocalBase = settingsFile.isLocalBase;
                isDefault = settingsFile.isDefault; ;
            }
            AssetDatabase.SaveAssets();//��������� ���������
        }

        buttonPress = GUILayout.Button("AAAAA");
        if (buttonPress)
        {
            foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//�� �������� ��������, ������� ������ � ���������� ��������
                settingsFile.isFireBase = isFireBase;
                settingsFile.isLocalBase = isLocalBase;
                settingsFile.isDefault = isDefault;
            }
            AssetDatabase.SaveAssets();//��������� ���������
        }

    }
}
