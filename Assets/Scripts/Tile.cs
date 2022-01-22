using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    int number;
    [SerializeField]
    int point;

    [SerializeField]
    Button buttonCompornent;

    [SerializeField]
    GameDirector gameDirector;

    private void Awake()
    {
        buttonCompornent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        gameDirector.players[gameDirector.players.Count-1].ownedTiles.Add(this);
        transform.SetParent(gameDirector.players[gameDirector.players.Count-1].gameObject.transform);
    }
}
