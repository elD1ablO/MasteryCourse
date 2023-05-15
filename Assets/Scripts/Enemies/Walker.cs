using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour, ITakeShellHits
{
    [SerializeField] private float speed = 1;
    [SerializeField] private GameObject spawnOnStompPrefab;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private Vector2 moveDirection = Vector2.left;

    private float offset = 0.1f;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + moveDirection * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEdge() || HitNonPlayer())
        {
            SwitchDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())            
        {
            if (collision.HitFromTop())
            {
                HandleWalkerStomped(collision.collider.GetComponent<PlayerMovementController>());
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void HandleWalkerStomped(PlayerMovementController playerMovementController)
    {
        if (spawnOnStompPrefab != null)
        {
            Instantiate(spawnOnStompPrefab, transform.position, transform.rotation);
        }
        
        playerMovementController.Bounce();

        Destroy(gameObject);
    }

    private bool HitNonPlayer()
    {
        float colliderEdgeXAxis = GetForwardXAxis();
        float colliderEdgeYAxis = transform.position.y;

        Vector2 origin = new Vector2(colliderEdgeXAxis, colliderEdgeYAxis);

        var raycastHit = Physics2D.Raycast(origin, moveDirection, 0.1f);

        if (raycastHit.collider == null || raycastHit.collider.isTrigger || raycastHit.collider.GetComponent<PlayerMovementController>() != null)
        {
            return false;
        }        

        return true;

    }

    private bool ReachedEdge()
    {
        float colliderEdgeXAxis = GetForwardXAxis();

        float colliderEdgeYAxis = collider.bounds.min.y;

        Vector2 origin = new Vector2(colliderEdgeXAxis, colliderEdgeYAxis);

        var raycastHit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        if (raycastHit.collider == null)
        {
            return true;
        }

        return false;
    }

    private float GetForwardXAxis()
    {
        return moveDirection.x == -1 ? collider.bounds.min.x - offset : collider.bounds.max.x + offset;        
    }

    private void SwitchDirection()
    {
        moveDirection *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        Destroy(gameObject);
    }
}
