using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Test1Enum { A, B, C, D }
public class Test1 : MonoBehaviour
{
    public Test1Enum test1Enum = Test1Enum.A;

    [HideInInspector] public string test1String;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
