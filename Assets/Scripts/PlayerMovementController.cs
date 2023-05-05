using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        

        Vector3 playerMovement = new Vector3(horizontalMovement, verticalMovement);
        
        transform.position += playerMovement * Time.deltaTime * movementSpeed;
    }
}
