using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test1))]
public class Test1Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Test1 t = target as Test1;

        if (t.test1Enum == Test1Enum.B)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("test1String"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
