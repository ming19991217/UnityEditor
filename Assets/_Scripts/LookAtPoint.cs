using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //在編輯模式執行
public class LookAtPoint : MonoBehaviour
{
    public float Y = 0;
    public Vector3 lookAtPoint = Vector3.zero;

    public void Update()
    {
        transform.LookAt(lookAtPoint);
    }
}