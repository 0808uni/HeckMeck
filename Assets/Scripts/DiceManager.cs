using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class DiceManager : MonoBehaviour
{
    [SerializeField]
    public List<DiceData> datas;

    [SerializeField]
    public List<Dice> dices;

    [SerializeField]
    Button resultButton;

    [SerializeField]
    GameObject selectedPanel;

    public int sum = 0;

    [SerializeField]
    Text sumCalc;

    private void Awake()
    {
        //gameObject.SetActive(false);
        resultButton.gameObject.SetActive(false);
        resultButton.onClick.AddListener(Result);
    }


    public void DiceClick(Dice dice)
    {
        //クリックしたサイコロと同数値の物が青く表示される
        //決定ボタンが出現する
        dices.ForEach(n => n.GetComponent<Image>().color = Color.white);
        dices.ForEach(n => n.isSelected = false);
        foreach (var d in dices)
        {
            if (d.diceData==dice.diceData)
            {
                d.GetComponent<Image>().color = Color.cyan;
                d.isSelected = true;
            }
        }
        resultButton.gameObject.SetActive(true);
    }

    private void Result()
    {
        //出現したボタンを押すと下部のパネルにサイコロが移動する
        foreach (var d in dices)
        {
            if (d.isSelected)
            {
                d.transform.SetParent(selectedPanel.transform);
                d.GetComponent<Image>().color = Color.white;
                sum += d.diceData.numData;
                d.enabled = false;
            }

            d.isRollable = true;
        }
        sumCalc.text = sum.ToString();
        
        resultButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

}

[Serializable]
public class DiceData
{
    public Sprite pipData;
    public int numData;
}
