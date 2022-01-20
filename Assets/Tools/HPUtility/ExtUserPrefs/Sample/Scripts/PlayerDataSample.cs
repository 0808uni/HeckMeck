using System.Collections.Generic;
using HKUtility;
using UnityEngine;

public class PlayerDataSample : MonoBehaviour
{
    [SerializeField]
    string saveFileName;

    // Use this for initialization
    void Start()
    {
        ExtUserPrefs.Save(SetData(), saveFileName);
    }

    static GameData SetData()
    {
        var playerData = new GameData
        {
            name = "ファルコン",
            hp = 27,
            mp = 10
        };

        playerData.item.weapon = new List<string> { "小型剣", "大剣" };
        playerData.item.weapon.Add("片手剣");
        playerData.item.armor = new List<string> { "兜", "鎧" };
        return playerData;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var data = ExtUserPrefs.Load<GameData>(saveFileName);

            Debug.Log($"名前 {data.name}");
            Debug.Log($"HP { data.hp}");
            Debug.Log($"MP {data.mp}");
            Debug.Log($"武器１ {data.item.weapon[0]}");
            Debug.Log($"防具１ {data.item.armor[0]}");
        }
    }
}
