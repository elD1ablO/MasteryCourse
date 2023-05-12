using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsAmountChanged += GameManager_OnCoinsAmountChanged;
    }

    private void GameManager_OnCoinsAmountChanged(int coins)
    {
        audioSource.Play();
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsAmountChanged -= GameManager_OnCoinsAmountChanged;
    }
}
