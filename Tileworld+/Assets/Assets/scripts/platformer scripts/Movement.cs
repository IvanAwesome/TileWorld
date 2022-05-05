using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 2;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    float movement;
    public SpriteRenderer sprite;
    Animator anim;
    public enum MovementState { idle, jumping }
    public MovementState state;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;


        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            state = MovementState.jumping;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (movement > 0f)
        {
   
            sprite.flipX = false;
        }
        else if (movement < 0)
        {
       
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (_rigidbody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
     
        anim.SetInteger("state", (int)state);
    }
}

