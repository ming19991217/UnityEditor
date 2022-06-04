using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestMenu : MonoBehaviour
{
    //頂部菜單欄擴展 
    [MenuItem("MING/Test1 %9", false, 1)]
    static void Test1()
    {
        Debug.Log("hahaha");
    }

    //頂部菜單欄擴展
    [MenuItem("MING/Test2 %#9", false, 20)]
    static void Test2()
    {
        Debug.Log("hahaha");
    }

    //頂部菜單欄擴展
    [MenuItem("MING/Test3", false, 3)]
    static void Test3()
    {
        Debug.Log("hahaha");
    }



    //判斷test1是否可以點擊
    [MenuItem("MING/Test1", true)]
    static bool Test1Validata()
    {
        //經過判讀後返回值 true可點擊 
        return false;
    }

    //擴展已有菜單
    [MenuItem("GameObject/Test1")]
    static void OBJTest1()
    {
        Debug.Log("hahaha");
    }




}
