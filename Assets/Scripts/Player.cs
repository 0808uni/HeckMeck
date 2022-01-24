using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//playerの持つタイルの情報を保持する
public class Player : MonoBehaviour
{
    [SerializeField]
    Text playerName;

    [SerializeField]
    public string myName;
    [SerializeField]
    public List<Tile> ownedTiles;

    private void Start()
    {
        playerName.text = myName;
    }
}
