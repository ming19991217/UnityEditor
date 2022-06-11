using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// Edior常用特性 
/// </summary>

//添加到component菜單    
//需要點擊一個gameobject才能添加組件
[AddComponentMenu("Menu Item Edior")]

//禁止添加多個組件
[DisallowMultipleComponent]

//在編輯模式下執行
//update會在改變物件的狀況下執行
[ExecuteInEditMode]

//給類提供一個自訂文檔url 在組件右邊的小問號
[HelpURL("https://play.google.com/store/apps/details?fbclid=IwAR2ifyaPTaoJO22WPgbBIZWCmbBwfZZiSmTNeDJUK25WZ53A_En57oLnCxc&id=com.VisionEdger.VisionEdger_1979.RD")]

//選擇子類會選擇到父類
[SelectionBase]

public class UnityAttribute : MonoBehaviour
{
    #region MenuItem
    //*************************************************
    //自訂新的菜單欄
    //方法必須為靜態方法
    //名字後方為快捷鍵  %=ctr #=shift  &=alt   F1-F12   _g=單個字母
    //*************************************************

    [MenuItem("MyTools/DeleteAllObj &d")]
    public static void MyToolDelete()
    {
        foreach (var item in Selection.objects)
        {
            //可撤銷的刪除功能
            Undo.DestroyObjectImmediate(item);
        }
    }

    //*************************************************
    //自訂組件右鍵菜單
    //給某個組件右鍵添加方法
    //格式( "CONTEXT/組件名/方法名")
    //MenuCommand 獲取當前組件
    //*************************************************
    [MenuItem("CONTEXT/Rigidbody/Init")]
    public static void MyRigidbodyMethod(MenuCommand cmd)
    {
        Rigidbody rb = cmd.context as Rigidbody; //獲取當前組件
        Debug.Log("rigidbody methid");
    }
    #endregion


    #region ContextMenu
    //*************************************************
    //ContextMenu
    //自訂組件右鍵菜單
    //和MenuItem+CONTEXT類似
    //注意！方法不能為靜態
    //*************************************************
    [ContextMenu("MyContextMenuMethod")]
    public void MyContextMenuMethod()
    {
        Debug.Log("context menu method");
    }

    //*************************************************
    //ContextMenuItem
    //自訂字段右鍵菜單
    //點擊”字段“的右鍵方法
    //綁定一個方法
    //*************************************************
    [ContextMenuItem("將f1設為10", nameof(HandleF1))]
    public float f1 = 0f;
    private void HandleF1() { f1 = 10; }

    #endregion


    #region Gizmos
    //*************************************************
    //在Scene窗口繪製 不在Game窗口繪製
    //OnDrawGizmos() 每一幀都會調用 其渲染的Gizmos是一直可見的
    //OnDrawGizmosSelected() 每一幀調用 當物體被選中時才會顯現
    //*************************************************

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 1);//畫一個黑色的方塊
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 5);
    }

    //*************************************************
    //DrawGizmos特性
    //根據GizmoType判斷去執行繪製
    //方法需為靜態
    //如果選中的物件是第一個參數的類型，並且符合GizmoType
    //*************************************************

    //需要物件激活並且是選擇狀態，才會繪製icon
    [DrawGizmo(GizmoType.Active | GizmoType.Selected)]
    public static void MyCustomOnGizmos(GameManager gm, GizmoType type)
    {
        // Gizmos.DrawSphere(gm.transform.position, .2f);
        Gizmos.DrawIcon(gm.transform.position, "1.jpg", true);
    }



    #endregion


    #region UnityEngine 特性

    //*************************************************
    //  delayed
    //運行調試時，延遲監控輸入
    //正常情況下，在編輯器改動參數時，會實時作出改變
    //當加上delayed特性，必須按下回車鍵才會作出改動
    //*************************************************

    [Delayed]
    public int i1;
    private void Update()
    {
        Debug.Log(i1);
    }

    //*************************************************
    //  Multiline
    //讓string多顯示幾行
    //不帶滾動條 無收縮功能
    //  TextArea
    //帶滾動條 有收縮功能
    //*************************************************

    [Multiline(5)]
    public string s1;

    //默認3行 超出自動顯示滾動條
    [TextArea]
    public string i2;
    [TextArea(1, 7)]
    public string i3;

    //*************************************************
    //  RuntimeInitializeOnLoadMethod
    //當場景完成載入調用
    //不用為組件添加到對象，也可以自動調用
    //*************************************************

    [RuntimeInitializeOnLoadMethod]
    private static void OnSceneLoad()
    {
        Debug.Log("load scene done");
    }

    //*************************************************
    //  Tooltip
    //提示
    //*************************************************

    [Tooltip("這是一個字段")]
    public int i4;

    #endregion


}
