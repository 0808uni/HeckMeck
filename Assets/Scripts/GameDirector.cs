using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ゲームを進行する役割
//ゲームが終わっているか否か、タイル・サイコロが引けるか否かの情報を渡す
public class GameDirector : MonoBehaviour
{
    [SerializeField]
    public List<Player> players;

    [SerializeField]
    public int playerTurn;

}
