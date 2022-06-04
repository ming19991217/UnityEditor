using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// LookAtPoint 客製化編輯器 
/// </summary>
[CustomEditor(typeof(LookAtPoint))] //客製化的腳本
[CanEditMultipleObjects] //可以選擇多個物件並同時改變他們
public class LookAtPointEditor : Editor
{
    SerializedProperty lookAtPoint;

    void OnEnable()
    {
        //獲取腳本中 v3類型的lookatpoint
        lookAtPoint = serializedObject.FindProperty("lookAtPoint");
    }



    public override void OnInspectorGUI() //在檢視面板中
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(lookAtPoint);
        serializedObject.ApplyModifiedProperties();

        if (lookAtPoint.vector3Value.y > (target as LookAtPoint).transform.position.y)
        {
            //添加文字組件
            EditorGUILayout.LabelField("(Above this object)");
        }
        if (lookAtPoint.vector3Value.y < (target as LookAtPoint).transform.position.y)
        {
            EditorGUILayout.LabelField("(Below this object)");
        }

        //按鈕
        if (GUILayout.Button("按鈕"))
        {
            Debug.Log("HaHAha");
        }
        //滑動調
     (target as LookAtPoint).Y = EditorGUILayout.Slider("滑動調", (target as LookAtPoint).Y, 0f, 100f);
    }

    public void OnSceneGUI() //在場景窗口
    {
        var t = (target as LookAtPoint);

        EditorGUI.BeginChangeCheck();
        //在場景中建立一個transform的把手
        Vector3 pos = Handles.PositionHandle(t.lookAtPoint, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Move point");
            t.lookAtPoint = pos;
            t.Update();
        }


    }

}
