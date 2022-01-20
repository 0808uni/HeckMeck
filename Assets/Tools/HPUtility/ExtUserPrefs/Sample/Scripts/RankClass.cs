using System;
using System.Collections.Generic;

[Serializable]
public class RankClass
{
    public string HiscoreRank = "ハイスコアランキング";
    public List<Member> members = new List<Member>();
}

[Serializable]
public class Member
{
    public string Name;
    public int Score;

    public Member(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
