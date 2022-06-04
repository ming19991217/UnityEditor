using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class TestSceneMenu : MonoBehaviour
{
    //Unity初始化時調用
    [InitializeOnLoadMethod]
    static void InitializeOnLoad()
    {
        //在場景窗口中事件
        SceneView.duringSceneGui += (sceneView) =>
        {
            //事件不為空 鼠標右鍵 鼠標抬起
            if (Event.current != null &&
            Event.current.button == 1 &&
            Event.current.type == EventType.MouseUp)
            {
                //Debug.Log("鼠標右鍵抬起");

                //菜單位置
                Rect position = new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100);
                GUIContent[] contents = new GUIContent[] { new GUIContent("Text1"), new GUIContent("MING/Text1") };


                EditorUtility.DisplayCustomMenu(position, contents, -1, (data, opt, select) => { Debug.LogFormat("data:{0},opt:{1},select:{2}", data, opt, select); }, null);

                //安完右鍵鼠標圖標會改變 使用use變回正常
                Event.current.Use();
            }
        };


    }
}
