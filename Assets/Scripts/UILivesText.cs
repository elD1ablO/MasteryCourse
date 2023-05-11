using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    private void Awake()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesAmountChanged += GameManager_OnLivesChanged;
        livesText.text = GameManager.Instance.Lives.ToString();
    }

    private void GameManager_OnLivesChanged(int livesRemaining)
    {
        livesText.text = livesRemaining.ToString();
    }   
}
