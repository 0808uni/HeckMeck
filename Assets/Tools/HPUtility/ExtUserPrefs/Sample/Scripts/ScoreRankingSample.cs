using HKUtility;
using UnityEngine;

public class ScoreRankingSample : MonoBehaviour
{
    [SerializeField]
    string saveFileName;

    // Use this for initialization
    void Start()
    {
        var ranking = new RankClass();
        // ランキングの設定
        ranking.members.Add(new Member("ファルコン", 100));
        ranking.members.Add(new Member("ミライ", 70));
        ranking.members.Add(new Member("カイリ", 50));

        // 保存
        ExtUserPrefs.Save(ranking, saveFileName);

        // ランキングデータの読み出し
        var rankLoadData = ExtUserPrefs.Load<RankClass>(saveFileName);

        // ランキングデータの表示
        foreach (var member in rankLoadData.members)
        {
            print($"名前：{member.Name}  スコア：{member.Score}");
        }
    }
}
