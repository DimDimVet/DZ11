using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ConfigEditor : EditorWindow
{
    private SerializedProperty healtPlayer;//ссылка на поле
    private SerializedProperty shootCount;//ссылка на поле
    private string[] playerList;

    [MenuItem("DZ11/Menu Config")]//обозначим в меню Window ссылку Game Setting Window
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConfigEditor));//GetWindow формирует окно 
    }

    void OnGUI()
    {
        playerList = AssetDatabase.FindAssets("Statistic");//поищем объекты с файлами settings

        GUILayout.Label("Set Mode", EditorStyles.boldLabel);//имя подраздела в окне
        foreach (var item in playerList)//опросим результат поиска в листе и выведем
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//выведем имя найденого
        }

    }
}
