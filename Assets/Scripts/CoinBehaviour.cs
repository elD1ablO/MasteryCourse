using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>() != null)
        {
            GameManager.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
