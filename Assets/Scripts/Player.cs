using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    Text playerName;

    [SerializeField]
    public string name;
    [SerializeField]
    public List<Tile> ownedTiles;

    private void Start()
    {
        playerName.text = name;
    }
}
