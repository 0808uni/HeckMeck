using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


//サイコロのオブジェクトにアタッチ
//サイコロの内部的なイベントはここで行う
//ここからDiceManagerのイベントを呼び出す
public class Dice : MonoBehaviour
{
    [SerializeField]
    public DiceData diceData;
    
    [SerializeField]
    public bool isRollable;
    [SerializeField]
    public bool isSelected;
    [SerializeField]
    public bool isSlectable;

    DiceManager diceManager;
    Button buttonComponent;

    private void Awake()
    {
        diceManager = gameObject.transform.parent.GetComponent<DiceManager>();
        buttonComponent = gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        //初期値＝１
        diceData = diceManager.diceDatas[0];
        isRollable = true;
        isSelected = false;
        isSlectable = true;

        buttonComponent.onClick.AddListener(OnClick);
    }


    private void Update()
    {
        //サイコロの画像を常に更新
        gameObject.GetComponent<Image>().sprite = diceData.pipData;
    }

    public void Roll()
    {
        //ランダムなインデックスを作成し、マネージャーのサイコロの大元の情報配列から引き出す
        int randomIndex = UnityEngine.Random.Range(0, 6);
        diceData = diceManager.diceDatas[randomIndex];
        isRollable = false;
    }

    private void OnClick()
    {
        //ボタンコンポーネントによりマネージャーのDiceClickメソッドが呼び出される
        diceManager.DiceClick(this);
    }
}
