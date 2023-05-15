
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMoveable
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 600f;
    [SerializeField] float wallJumpForce = 300f;
    [SerializeField] float bounceForce = 400f;

    private new Rigidbody2D rigidbody2D;
    private CharacterGrounding characterGrounding;

    public float Speed { get; private set; }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterGrounding.IsGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);

            if (characterGrounding.GroundedDirection != Vector2.down)
            {
                rigidbody2D.AddForce(characterGrounding.GroundedDirection * -1f * wallJumpForce);
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");     

        Speed = horizontalMovement;

        Vector3 playerMovement = new Vector3(horizontalMovement, 0);
        
        transform.position += playerMovement * Time.deltaTime * movementSpeed;
                
    }

    public void Bounce()
    {        
        rigidbody2D.AddForce(Vector2.up * bounceForce);
    }
}
