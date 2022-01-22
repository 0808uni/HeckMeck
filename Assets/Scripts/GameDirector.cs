using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    public List<Player> players;

    [SerializeField]
    public int playerTurn;

    private void Start()
    {

    }
}
