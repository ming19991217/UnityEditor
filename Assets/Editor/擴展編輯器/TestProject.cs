using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestProject : MonoBehaviour
{
    //專案窗口 
    [MenuItem("Assets/Test1")]
    static void Test1()
    {
        Debug.Log("test project test1");


    }

    [InitializeOnLoadMethod]
    static void InitializeOnLoad()
    {
        EditorApplication.projectWindowItemOnGUI += (guid, rect) =>
            {
                //選擇物件不為空
                if (Selection.activeObject != null)
                {
                    //獲得當前選擇的guid
                    string active_guid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(Selection.activeGameObject));

                    //比較是否和
                    if (active_guid == guid)
                    {

                        rect.x = rect.width - 100;
                        rect.width = 100;
                        if (GUI.Button(rect, "Test1"))
                        {
                            Debug.Log("刪除文件:" + AssetDatabase.GetAssetPath(Selection.activeGameObject));
                            AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(Selection.activeGameObject));
                        }
                    }


                }
            };
    }
}
