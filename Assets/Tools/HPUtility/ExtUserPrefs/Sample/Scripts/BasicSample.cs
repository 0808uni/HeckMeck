using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// インスタンスの保存、読み出しの基本サンプルになります
/// </summary>
public class BasicSample : MonoBehaviour
{
    void Start()
    {
        MyClass myObject = new MyClass();
        myObject.Level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "ファルコン";

        string json = JsonUtility.ToJson(myObject);
        Debug.Log(json);
        Debug.Log("");

        MyClass loadObject = JsonUtility.FromJson<MyClass>(json);
        Debug.Log(loadObject.Level);
        Debug.Log(loadObject.items[1]);
        Debug.Log(loadObject.conVJtoE["いち"]);
        loadObject.Run();
    }
}

// シリアライズ化は必須。ファイルで読み書きできる状態にします。
[Serializable]
public class MyClass
{

    public string playerName;
    // プライベート（プロパティ含む）の場合、シリアライズフィールドとすること
    [SerializeField]
    public int level;
    public int Level { get => level; set => level = value; }

    // 時間経過
    public float timeElapsed;

    public List<string> items = new List<string>
    {
        "短剣",
        "ライフル"
    };

    public Dictionary<string, string> conVJtoE = new Dictionary<string, string>
    {
        ["いち"] = "One",
        ["に"] = "Two"
    };

    public void Run()
    {
        Debug.Log("走る");
    }
}

