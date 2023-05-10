using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

    private void Awake()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        GameManager.Instance.OnCoinsAmountChanged += GameManager_OnCoinsAmountChanged;        
    }

    private void GameManager_OnCoinsAmountChanged(int coinsAmount)
    {
        coinsText.text = coinsAmount.ToString();
    }
}
