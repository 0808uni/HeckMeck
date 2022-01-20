using System;
using HKUtility;
using UnityEngine;


[Serializable]
public class HiScoreDataClass
{
    public string name;
    public int hiScore;
}

public class HiScoreSample : MonoBehaviour
{
    HiScoreDataClass topPlayer = new HiScoreDataClass();

    void Start()
    {
        topPlayer.name = "コナン";
        topPlayer.hiScore = 1000;
    }

    void Update()
    {
        // 保存
        if (Input.GetKeyDown(KeyCode.S))
        {
            var json = ExtUserPrefs.Save(topPlayer, "HiScore");
            Debug.Log(json);
        }
        // 読み出し
        if (Input.GetKeyDown(KeyCode.L))
        {
            var data = ExtUserPrefs.Load<HiScoreDataClass>("HiScore");
            //表示
            print($"名前　  {data.name}");
            print($"スコア　{data.hiScore}");
        }
    }
}