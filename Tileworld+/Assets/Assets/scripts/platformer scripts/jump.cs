using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody2D rb2;
    private CircleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    MovementState state;

    private float dirX = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float playerMoveSpeed = 5f;
    [SerializeField] private float playerJumpHeight = 15f;

    private enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb2.velocity = new Vector2(dirX * playerMoveSpeed, rb2.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2.velocity.y) < 0.001f)
        {
            rb2.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (rb2.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

    }
}


