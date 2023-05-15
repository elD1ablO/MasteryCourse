using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsAmountChanged += GameManager_OnCoinsAmountChanged; 
    }

    private void GameManager_OnCoinsAmountChanged(int coins)
    {
        animator.SetTrigger("Pulse");
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsAmountChanged -= GameManager_OnCoinsAmountChanged;
    }
}
