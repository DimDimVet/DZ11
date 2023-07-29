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

    [MenuItem("DZ11/Menu Config")]//обозначим в меню Window ссылку Game Setting Window

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConfigEditor));//GetWindow формирует окно 
    }

    void OnGUI()
    {
        settingsList = AssetDatabase.FindAssets("t:settingsLoadData");//поищем объекты с файлами settings
        //
        isFireBase = EditorGUILayout.Toggle("Fire Base", isFireBase);
        isLocalBase = EditorGUILayout.Toggle("Local Base", isLocalBase);
        isDefault = EditorGUILayout.Toggle("Default", isDefault);
        //
        GUILayout.Label("Connect Settings:", EditorStyles.boldLabel);//имя подраздела в окне
        foreach (var item in settingsList)//опросим результат поиска в листе и выведем
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//выведем имя найденого
            GUILayout.Space(10);//пропуск пробел в пикселях
 
        }

        buttonPress = GUILayout.Button("BBBBB");
        if (buttonPress)
        {
            foreach (var item in settingsList)//опросим результат поиска в листе и выведем
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//из найденых сетингов, получим доступ к параметрам сеттинга
                isFireBase = settingsFile.isFireBase;
                isLocalBase = settingsFile.isLocalBase;
                isDefault = settingsFile.isDefault; ;
            }
            AssetDatabase.SaveAssets();//сохранить изменения
        }

        buttonPress = GUILayout.Button("AAAAA");
        if (buttonPress)
        {
            foreach (var item in settingsList)//опросим результат поиска в листе и выведем
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//из найденых сетингов, получим доступ к параметрам сеттинга
                settingsFile.isFireBase = isFireBase;
                settingsFile.isLocalBase = isLocalBase;
                settingsFile.isDefault = isDefault;
            }
            AssetDatabase.SaveAssets();//сохранить изменения
        }

    }
}
