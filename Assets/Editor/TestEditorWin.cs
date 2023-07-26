using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestEditorWin : EditorWindow
{
    private string[] settingsList;

    private bool buttonPress;

    [MenuItem("Window/Game Setting Window")]//обозначим в меню Window ссылку Game Setting Window
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TestEditorWin));//GetWindow формирует окно 
    }

    void OnGUI()
    {
        GUILayout.Label("Game Setting", EditorStyles.boldLabel);//имя подраздела в окне

        settingsList = AssetDatabase.FindAssets("t:settings");//поищем объекты с файлами settings
        GUILayout.Label("Game Settings",EditorStyles.boldLabel);//имя подраздела в окне
        GUILayout.Space(10);//пропуск пробел в пикселях
        foreach (var item in settingsList)//опросим результат поиска в листе и выведем
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//выведем имя найденого
        }

        buttonPress = GUILayout.Button("AAAAA");
        if (buttonPress)
        {
            foreach (var item in settingsList)//опросим результат поиска в листе и выведем
            {
                var settingsFile = AssetDatabase.LoadAssetAtPath<Settings>(AssetDatabase.GUIDToAssetPath(item));//из найденых сетингов, получим доступ к параметрам сеттинга
                settingsFile.HealtPlayer += 100;//к параметру сеттинга введем значение
            }
            AssetDatabase.SaveAssets();//сохранить изменения
        }

    }
}
