using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddCoin();
        Destroy(gameObject);
    }
}
