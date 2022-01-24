using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


//ゲームを進行する役割
//ゲームが終わっているか否か、タイル・サイコロが引けるか否かの情報を渡す
public class GameDirector : MonoBehaviour
{
    [SerializeField]
    public List<Player> players;

    [SerializeField]
    public int playerTurn;

    [SerializeField]
    TileManager tileManager;
    [SerializeField]
    GameObject dobonText;

    public IEnumerator Dobon()
    {
        yield return new WaitForSeconds(1);

        dobonText.SetActive(true);

        //playerに所有されていない中で最大の
        tileManager.tiles.Where(n => !n.isOwned).
            Last().GetComponent<Image>().sprite=null;
    }
}
