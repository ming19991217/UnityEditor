using UnityEditor;
using UnityEngine;
/// <summary>
/// https://chowdera.com/2022/01/202201020001037740.html 
/// </summary>

public class ExampleWindow : EditorWindow
{
    string myString = "Hello World";

    [MenuItem("Window/Example")]
    public static void ShowWindow() //開啟視窗
    {
        EditorWindow.GetWindow<ExampleWindow>("編輯器標題");
    }

    private void OnGUI()
    {
        // window code
        //標籤（文字）
        GUILayout.Label("This is a label.", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("This is a label.", EditorStyles.boldLabel);

        //文字輸入框 (輸入框名稱，預設文字)
        myString = EditorGUILayout.TextField("Name", myString);

        //按鈕
        if (GUILayout.Button("Press Me"))
        {
            Debug.Log("Boutton is press");
            if (EditorApplication.isPlaying)
            {
                GameManager.instance.Hi();
            }
            else
            {
                Debug.LogWarningFormat("只能在播放模式進行");
            }
        }


    }



}
