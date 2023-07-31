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

    [MenuItem("DZ11/Menu Config")]//обозначим в меню Window ссылку Game Setting Window

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConfigEditor));//GetWindow формирует окно 
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
        GUILayout.Space(10);//пропуск пробел в пикселях
        //
        isFireBase = EditorGUILayout.Toggle("Fire Base", isFireBase);
        isLocalBase = EditorGUILayout.Toggle("Local Base", isLocalBase);
        isDefault = EditorGUILayout.Toggle("Default", isDefault);
        GUILayout.Space(10);//пропуск пробел в пикселях
        isSave = EditorGUILayout.Toggle("Включить сохранение", isSave);
        //
        GUILayout.Label("Connect Settings:", EditorStyles.boldLabel);//имя подраздела в окне

        foreach (var item in settingsList)//опросим результат поиска в листе и выведем
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//выведем имя найденого
            GUILayout.Space(10);//пропуск пробел в пикселях

        }
    }
    private void ButtonCurrentMode(string[] settingsList)
    {
        buttonPress = GUILayout.Button("Текущая установка");
        if (buttonPress)
        {
            foreach (var item in settingsList)//опросим результат поиска в листе и выведем
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//из найденых сетингов, получим доступ к параметрам сеттинга
                isFireBase = settingsFile.isFireBase;
                isLocalBase = settingsFile.isLocalBase;
                isDefault = settingsFile.isDefault;
                isSave = settingsFile.isSave;
            }
            AssetDatabase.SaveAssets();//сохранить изменения
        }
    }
    private void ButtonNewMode(string[] settingsList)
    {
        buttonPress = GUILayout.Button("Ввод установки");
        if (buttonPress)
        {
            foreach (var item in settingsList)//опросим результат поиска в листе и выведем
            {
                settingsFile = AssetDatabase.LoadAssetAtPath<SettingsLoadData>(AssetDatabase.GUIDToAssetPath(item));//из найденых сетингов, получим доступ к параметрам сеттинга
                settingsFile.isFireBase = isFireBase;
                settingsFile.isLocalBase = isLocalBase;
                settingsFile.isDefault = isDefault;
                settingsFile.isSave = isSave;
            }
            AssetDatabase.SaveAssets();//сохранить изменения
            settingsFile.isStartUpload = true;
        }
    }
    void OnGUI()
    {
        GUIToggleControl();//контролим состояние включения toggle

        settingsList = AssetDatabase.FindAssets("t:settingsLoadData");//поищем объекты с файлами settings
        GUIStart(settingsList);//сформируем элементы окна
        ButtonCurrentMode(settingsList);//логика кнопки по опросу сеттинга
        GUILayout.Space(10);//пропуск пробел в пикселях
        ButtonNewMode(settingsList);//логика кнопки по изменению сеттинга

    }
}
