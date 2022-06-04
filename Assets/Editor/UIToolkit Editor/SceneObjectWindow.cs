using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;
using System.Collections.Generic;

public class SceneObjectWindow : EditorWindow
{

    private ObjectField objectField;
    private Button createBtn;
    private Button refreshBtn;

    private ListView listView;
    private GameObject[] sceneObjects;
    private TextField nameText;
    private Vector3Field posText;
    private TextField tempTextField;

    [MenuItem("Window/UI Toolkit/SceneObjectWindow")]
    public static void ShowExample()
    {
        SceneObjectWindow wnd = GetWindow<SceneObjectWindow>();
        wnd.titleContent = new GUIContent("SceneObjectWindow");
    }

    //初始化視窗
    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UIToolkit Editor/SceneObjectWindow.uxml");
        visualTree.CloneTree(root);

        //性息框
        var helpBox = new HelpBox("一個演示!", HelpBoxMessageType.None);
        var helpBox2 = new HelpBox("一個演示!", HelpBoxMessageType.Info);
        var helpBox3 = new HelpBox("一個演示!", HelpBoxMessageType.Error);
        var helpBox4 = new HelpBox("一個演示!", HelpBoxMessageType.Warning);

        //獲得組件
        var rightVE = root.Q<VisualElement>("right");
        //添加消息組件
        rightVE.Add(helpBox);
        rightVE.Add(helpBox2);
        rightVE.Add(helpBox3);
        rightVE.Add(helpBox4);

        //
        objectField = root.Q<ObjectField>("ObjectField");
        objectField.objectType = typeof(GameObject); //設定物件類型
        objectField.allowSceneObjects = false; //允許使用scene物件
        //
        createBtn = root.Q<Button>("CreateBtn");
        createBtn.clicked += OnCreateGameObject;
        //
        refreshBtn = root.Q<Button>("RefreshBtn");
        refreshBtn.clicked += OnRefresh;
        //
        listView = root.Q<ListView>("ListView");
        //当 ListView 需要更多项目来呈现时
        Func<VisualElement> makeItem = () =>
        {
            var Label = new Label();
            Label.style.unityTextAlign = TextAnchor.MiddleLeft;
            Label.style.marginLeft = 5;
            return Label;
        };
        // 当用户滚动列表时，ListView 对象
        // 将回收由“makeItem”创建的元素
        // 并调用“bindItem”回调进行关联
        // 具有匹配数据项的元素（在列表中指定为索引）
        Action<VisualElement, int> bindItem = (e, i) => { (e as Label).text = sceneObjects[i].name; };
        listView.makeItem = makeItem;
        listView.bindItem = bindItem;
        listView.onSelectionChange += OnSelectItem;

        //
        nameText = root.Q<TextField>("NameText");
        nameText.bindingPath = "m_Name";//進行數據綁定
        //
        // m_Name 是unity內部的叫法，需要查看屬性路徑，可按住shift+右鍵點檢視窗口屬性，列印屬性路徑
        //
        posText = root.Q<Vector3Field>("PosText");
        posText.bindingPath = "m_LocalPosition";//進行數據綁定
        //
        tempTextField = root.Q<TextField>("tempTextField");
        tempTextField.RegisterValueChangedCallback<string>(OnTextFieldChanged);//當數值改變時調用



    }

    //當數值改變時調用
    private void OnTextFieldChanged(ChangeEvent<string> evt)
    {
        Debug.Log("Old:" + evt.previousValue + "New:" + evt.newValue);
    }

    //選擇列表框中的物件
    private void OnSelectItem(IEnumerable<object> obj)
    {
        foreach (var item in obj)
        {
            var go = item as GameObject;
            Selection.activeGameObject = go;
            //nameText.value = go.name;
            //posText.value = go.transform.localPosition;

            //進行數據綁定
            SerializedObject so = new SerializedObject(go);
            nameText.Bind(so);

            SerializedObject so2 = new SerializedObject(go.transform);
            posText.Bind(so2);


        }
    }


    private void OnRefresh()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneObjects = scene.GetRootGameObjects(); //獲得場景物件
        listView.itemsSource = sceneObjects;//設置listview的數據源
    }

    private void OnCreateGameObject()
    {
        //獲取objectField的值
        GameObject prefab = objectField.value as GameObject;

        var go = GameObject.Instantiate<GameObject>(prefab);
        go.transform.position = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1, 1));
    }

    private void OnGUI()
    {
        Debug.Log("在UI上");
    }

}