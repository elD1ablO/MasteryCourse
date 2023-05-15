using UnityEngine;

public class ShellFlipped : MonoBehaviour
{
    [SerializeField] private float shellSpeed = 4f;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody;

    private Vector2 direction;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(direction.x * shellSpeed, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())
        {
            HandlePlayerCollision(collision);
        }
        else
        {
            if (collision.HitFromSide())
            {
                LaunchShell(collision);

                var takeShellHits = collision.collider.GetComponent<ITakeShellHits>();
                if (takeShellHits != null)
                {
                    takeShellHits.HandleShellHit(this);
                }
            }
        }
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();

        if (direction.magnitude == 0)
        {
            LaunchShell(collision);

            if (collision.HitFromTop())
            {
                playerMovementController.Bounce();
            }
        }
        else
        {
            if (collision.HitFromTop())
            {
                direction = Vector2.zero;
                playerMovementController.Bounce();
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void LaunchShell(Collision2D collision)
    {
        float launchDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;

        direction = Vector2.right * launchDirection;
    }
}
