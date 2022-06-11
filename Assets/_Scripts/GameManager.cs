using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct TestStruct
{
    public enum Mode { A, B, C, D, E }

    public int a;
    public string b;
    public bool c;
    public Mode mode;
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TestStruct[] testList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hi()
    {
        print("hi");
    }
}
