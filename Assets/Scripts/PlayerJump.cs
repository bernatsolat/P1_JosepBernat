using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    private Animator Animator;
    public float TimeToMaxHeight;
    private float Vertical;


    private CollisionDetection _collisionDetection;
    private Rigidbody2D _rigidbody;

    // TODO: Add variables to track number of jumps
    public int MaxJumps = 4;
    private int JumpCount = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();
        Animator = GetComponent<Animator>();

    }

    void Update()
    {
        Vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
            Animator.SetBool("jump",Vertical <= 0.0f);

        }
    }

    void TryJump()
    {
        if (CanJump()) OnJump();
    }

    bool CanJump()
    {
        // TODO: Check also number of jumps
        return _collisionDetection.IsGrounded || JumpCount < MaxJumps;
    }

    public void OnJump()
    {
        SetGravity();
        var vel = new Vector2(_rigidbody.velocity.x, GetJumpForce());
        _rigidbody.velocity = vel;

        // TODO: Count number of jumps
        JumpCount++;
    }

    private float GetJumpForce()
    {
        return (2 * JumpHeight / TimeToMaxHeight);
    }

    private void SetGravity()
    {
        
        // TODO: Scale gravity by jumps done
        var grav = 2 * JumpHeight / (TimeToMaxHeight * TimeToMaxHeight);
        _rigidbody.gravityScale = grav / 9.81f * (1 + 0.25f * JumpCount);
    }

    void OnLanding()
    {
        // TODO: Reset jumps and gravity
        JumpCount = 0;
        _rigidbody.gravityScale = 1;
    }
}
