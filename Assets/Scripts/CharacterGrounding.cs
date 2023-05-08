using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{

    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded {  get; private set; }

    private void Update()
    {
        CheckGrounding(leftFoot);

        if (IsGrounded == false)
            CheckGrounding(rightFoot);
    }

    private void CheckGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(foot.position, Vector3.down * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
        
}
