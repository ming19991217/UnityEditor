using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class ReorderableListEditor : Editor
{
    SerializedProperty textSructs;
    ReorderableList list;

    private void OnEnable()
    {

        textSructs = serializedObject.FindProperty("testList");

        list = new ReorderableList(serializedObject, textSructs, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;

    }

    private void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);

        EditorGUI.PropertyField(new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight),
        element.FindPropertyRelative("mode"), GUIContent.none);

        EditorGUI.PropertyField(new Rect(rect.x + 120, rect.y, 100, EditorGUIUtility.singleLineHeight),
        element.FindPropertyRelative("a"), GUIContent.none);

        EditorGUI.PropertyField(new Rect(rect.x + 220, rect.y, 100, EditorGUIUtility.singleLineHeight),
        element.FindPropertyRelative("b"), GUIContent.none);
    }

    private void DrawHeader(Rect rect)
    {
        string name = "Test";
        EditorGUI.LabelField(rect, name);
    }

    public override void OnInspectorGUI()
    {
        //   base.OnInspectorGUI();

        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
