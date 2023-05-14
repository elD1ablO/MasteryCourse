using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody2D;

    private Vector2 moveDirection = Vector2.left;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + moveDirection * speed * Time.deltaTime);
    }
}
