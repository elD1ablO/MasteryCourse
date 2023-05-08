using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 400f;

    private new Rigidbody2D rigidbody2D;
    private CharacterGrounding characterGrounding;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");     

        Vector3 playerMovement = new Vector3(horizontalMovement, 0);
        
        transform.position += playerMovement * Time.deltaTime * movementSpeed;

        if (Input.GetKey(KeyCode.Space) && characterGrounding.IsGrounded)
        {            
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
