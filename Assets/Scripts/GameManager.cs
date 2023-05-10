using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lives {  get; private set; }

    public event Action<int> OnLivesAmountChanged;
    public event Action<int> OnCoinsAmountChanged;

    private int coinCounter;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            RestartGame();
        }        
    }

    public void KillPlayer()
    {
        Lives--;
        OnLivesAmountChanged?.Invoke(Lives);

        if (Lives <= 0)
        {
            RestartGame();
        }        
    }

    private void RestartGame()
    {
        Lives = 3;
        coinCounter = 0;

        OnCoinsAmountChanged?.Invoke(coinCounter);
        SceneManager.LoadScene(0);
    }

    public void AddCoin()
    {
        coinCounter++;
        OnCoinsAmountChanged?.Invoke(coinCounter);
    }
}
