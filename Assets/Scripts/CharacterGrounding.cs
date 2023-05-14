using System;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{

    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded {  get; private set; }

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;

    private void Update()
    {
        CheckGrounding(leftFoot);

        if (IsGrounded == false)
            CheckGrounding(rightFoot);

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

    private void CheckGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(foot.position, Vector3.down * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
            groundedObject = raycastHit.collider.transform;
            IsGrounded = true;
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }
        
}
