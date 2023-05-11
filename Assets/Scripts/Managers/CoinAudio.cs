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
        GameManager.Instance.OnCoinsAmountChanged += (coins) => audioSource.Play();
    }
}
