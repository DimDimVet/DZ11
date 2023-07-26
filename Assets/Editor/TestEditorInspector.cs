using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CanEditMultipleObjects]//атрибут выбора объектов одного типа
[CustomEditor(typeof(Settings))]//данный инспектор показывать при выборе объекта сеттинга
public class TestEditorInspector : Editor
{
    private SerializedProperty health;//ссылка на поле
    private bool setHealth;

    private void OnEnable()
    {
        health = serializedObject.FindProperty("HealtPlayer");//и привезали это поле к реальному полю в скрипте сеттинга
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();//обновляем в апдейте
        //
        GUILayout.Label(health.intValue.ToString());//и через гуи выводим значение(intValue)
        base.OnInspectorGUI();//или выведем из базового метода базовую вид
        GUILayout.Space(10);//пропуск пробел в пикселях
        //
        EditorGUILayout.PropertyField(health);//найдем все поля
        GUILayout.Label(health.intValue.ToString());//выведем просто название
        setHealth = GUILayout.Button("Set Health back to 100");//создадим кнопку в инспекторе и дадим ей имя
        if (setHealth)//опишем логику кнопки
        {
            health.intValue = 100;//зададим значение в поле health
        }
        serializedObject.ApplyModifiedProperties();//изменить во всех найденых полях, примение редакции
    }

    private void OnSceneGUI()//то же только в окне сцены
    {
        Vector3 newVector = new Vector3(4,5,6);//в сцене указываем вектор позиции
        Handles.Label(newVector,"Что то");
    }
}
