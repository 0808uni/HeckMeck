﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


//playerの持つタイルの情報を保持する
public class Player : MonoBehaviour
{
    [SerializeField]
    Text playerName;

    [SerializeField]
    public string myName;
    [SerializeField]
    public List<Tile> ownedTiles;

    GameDirector gameDirector;
    GameObject playerBoard;

    private void Awake()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        playerBoard = GameObject.Find("PlayerBoard");
    }
    private void Start()
    {
        playerName.text = myName;
        gameDirector.players.Add(this);
        this.transform.SetParent(playerBoard.transform,false);
    }

    public void Owning(Tile tile)
    {
        if (ownedTiles.Count>0)
        {
            ownedTiles.Last().GetComponent<Button>().interactable = false;
        }

        ownedTiles.Add(tile);
        tile.transform.SetParent(transform);
        tile.transform.position = transform.position;

        gameDirector.NextTurn();
    }
}
