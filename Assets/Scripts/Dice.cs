using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Dice : MonoBehaviour
{
    [SerializeField]
    public DiceData diceData;
    [SerializeField]
    public bool isRollable;
    [SerializeField]
    public bool isSelected;

    DiceManager diceManager;

    Button buttonComponent;

    private void Awake()
    {
        diceManager = gameObject.transform.parent.GetComponent<DiceManager>();
        buttonComponent = gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        diceData = diceManager.datas[0];
        isRollable = true;
        isSelected = false;

        buttonComponent.onClick.AddListener(OnClick);
    }


    private void Update()
    {
        //サイコロの画像を常に更新、isRollableが正の時に画面をタップ（クリック）で振れる
        gameObject.GetComponent<Image>().sprite = diceData.pipData;

        if (Input.GetMouseButtonDown(0)&&isRollable)
        {
            Roll();
        }
    }

    private void Roll()
    {
        //ランダムなインデックスを作成し、マネージャーのサイコロの大元の情報配列から引き出す
        int randomIndex = UnityEngine.Random.Range(0, 6);
        diceData = diceManager.datas[randomIndex];
        isRollable = false;
    }

    private void OnClick()
    {
        //ボタンコンポーネントによりマネージャーのDiceClickメソッドが呼び出される
        diceManager.DiceClick(this);
    }
}
