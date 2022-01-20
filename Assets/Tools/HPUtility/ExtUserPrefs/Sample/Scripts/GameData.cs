using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public string name;
    public int hp;
    public int mp;
    public Item item = new Item();
}

[Serializable]
public class Item
{
    public List<string> weapon;
    public List<string> armor;
}
