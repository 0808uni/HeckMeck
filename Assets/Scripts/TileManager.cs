using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

//タイルを内容する
//タイルに関するイベントを行う
//タイルは画像を差し替えたりしないのでSerializableで扱うことはしない
//単純に場に存在するタイルを配列でまとめ、取得されれば消していく
public class TileManager : MonoBehaviour
{
    [SerializeField]
    public List<Tile> tiles;

    [SerializeField]
    GameDirector gameDirector;

    Player currentPlayer;

    DiceManager diceManager;

    private void Update()
    {
        currentPlayer = gameDirector.players[gameDirector.playerTurn];
    }

    internal void PermitToGet(int sum)
    {
        foreach (var t in tiles.Where(t => t.num <= sum))
        {
            t.GetComponent<Button>().interactable = true;
        }
    }

    public void TileClick(Tile tile)
    {
        currentPlayer.ownedTiles.Add(tile);
        tile.gameObject.transform.SetParent(currentPlayer.transform);
        tile.transform.position = currentPlayer.transform.position;
    }


}