using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//タイルのオブジェクトにアタッチ
//TileManagerのイベントを呼び出す
public class Tile : MonoBehaviour
{
    [SerializeField]
    int num;
    [SerializeField]
    int point;
    
    [SerializeField]
    public bool isSlectable;
    [SerializeField]
    public bool isSelected;

    TileManager tileManager;
    
    Button buttonCompornent;

    private void Awake()
    {
        tileManager = gameObject.transform.parent.GetComponent<TileManager>();
        buttonCompornent = gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        buttonCompornent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        tileManager.TileClick(this);
    }
}
