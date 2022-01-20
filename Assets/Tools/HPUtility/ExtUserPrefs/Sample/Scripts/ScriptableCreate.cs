using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data")]
public class ScriptableCreate : ScriptableObject
{
    public int this[string name]
    {
        get
        {
            return itemList.First(item => item.name == name).number;
        }
    }

    public int hp;

    public List<MyItem> itemList;

    [Serializable]
    public class MyItem
    {
        public string name;

        public int number;
    }
}