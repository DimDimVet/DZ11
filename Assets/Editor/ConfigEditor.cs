using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//[CustomEditor(typeof(Statistic))]
public class ConfigEditor : EditorWindow
{
    //private string settings = "t:SettingsLoadData";
    private SettingsLoadData settingsFile;
    public bool isFireBase = true;
    public bool isLocalBase = false;
    public bool isDefault = false;
    public bool isSave = true;

    private string[] settingsList;
    private bool buttonPress;

    [MenuItem("DZ11/Menu Config")]//��������� � ���� Window ������ Game Setting Window

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConfigEditor));//GetWindow ��������� ���� 
    }

    private void GUIToggleControl()
    {
        if (isFireBase)
        {
            isLocalBase = false;
            isDefault = false;
        }
        else if (isLocalBase)
        {
            isFireBase = false;
            isDefault = false;
        }
        else if (isDefault)
        {
            isFireBase = false;
            isLocalBase = false;
        }
    }
    private void GUIStart(string[] settingsList)
    {
        GUILayout.Space(10);//������� ������ � ��������
        //
        isFireBase = EditorGUILayout.Toggle("Fire Base", isFireBase);
        isLocalBase = EditorGUILayout.Toggle("Local Base", isLocalBase);
        isDefault = EditorGUILayout.Toggle("Default", isDefault);
        GUILayout.Space(10);//������� ������ � ��������
        isSave = EditorGUILayout.Toggle("�������� ����������", isSave);
        //
        GUILayout.Label("Connect Settings:", EditorStyles.boldLabel);//��� ���������� � ����

        foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//������� ��� ���������
            GUILayout.Space(10);//������� ������ � ��������

        }
    }
    private void ButtonCurrentMode(string[] settingsList)
    {
        buttonPress = GUILayout.Button("������� ���������");
        if (buttonPress)
        {
            foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//�� �������� ��������, ������� ������ � ���������� ��������
                isFireBase = settingsFile.isFireBase;
                isLocalBase = settingsFile.isLocalBase;
                isDefault = settingsFile.isDefault;
                isSave = settingsFile.isSave;
            }
            AssetDatabase.SaveAssets();//��������� ���������
        }
    }
    private void ButtonNewMode(string[] settingsList)
    {
        buttonPress = GUILayout.Button("���� ���������");
        if (buttonPress)
        {
            foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//�� �������� ��������, ������� ������ � ���������� ��������
                settingsFile.isFireBase = isFireBase;
                settingsFile.isLocalBase = isLocalBase;
                settingsFile.isDefault = isDefault;
                settingsFile.isSave = isSave;
            }
            AssetDatabase.SaveAssets();//��������� ���������
            settingsFile.isStartUpload = true;
        }
    }
    void OnGUI()
    {
        GUIToggleControl();//��������� ��������� ��������� toggle

        settingsList = AssetDatabase.FindAssets("t:settingsLoadData");//������ ������� � ������� settings
        GUIStart(settingsList);//���������� �������� ����
        ButtonCurrentMode(settingsList);//������ ������ �� ������ ��������
        GUILayout.Space(10);//������� ������ � ��������
        ButtonNewMode(settingsList);//������ ������ �� ��������� ��������

    }
}
