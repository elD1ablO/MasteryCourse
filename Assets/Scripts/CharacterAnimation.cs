using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private IMoveable characterMover;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterMover = GetComponent<IMoveable>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float speed = characterMover.Speed;
        
        if (speed != 0)
            spriteRenderer.flipX = speed > 0;

        animator.SetFloat("Speed", Mathf.Abs(speed));
    }
}
