using System;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    public Vector2 GroundedDirection {  get; private set; }

    [SerializeField] private Transform[] positions;
    
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded {  get; private set; }

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;

    private void Update()
    {
        foreach (var position in positions)
        {
            CheckGrounding(position);
            if (IsGrounded)
            {
                break;
            }
        }
        StickToMovingObjects();
    }

    private void StickToMovingObjects()
    {
        if (groundedObject != null)
        {
            if (groundedObjectLastPosition.HasValue && groundedObjectLastPosition.Value != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;

                transform.position += delta;
            }
            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private void CheckGrounding(Transform footTransform)
    {
        var raycastHit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);
        Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
            if(groundedObject != raycastHit.collider.transform)
            {
                groundedObject = raycastHit.collider.transform;
                IsGrounded = true;
                groundedObjectLastPosition= groundedObject.position;

                GroundedDirection = footTransform.forward;
            }
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }
        
}
