using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float TimeToMaxHeight;
    private float Vertical;

    private CollisionDetection _collisionDetection;
    private Rigidbody2D _rigidbody;
    public int MaxJumps = 4;
    private int JumpCount = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();
    }

    void Update()
    {
        Vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    void TryJump()
    {
        if (CanJump()) OnJump();
    }

    bool CanJump()
    {
        return _collisionDetection.IsGrounded || JumpCount < MaxJumps;
    }

    public void OnJump()
    {
        SetGravity();
        var vel = new Vector2(_rigidbody.velocity.x, GetJumpForce());
        _rigidbody.velocity = vel;

        JumpCount++;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Jump);

        var playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.OnJump();
        }
    }

    private float GetJumpForce()
    {
        return (2 * JumpHeight / TimeToMaxHeight);
    }

    private void SetGravity()
    {
        var grav = 2 * JumpHeight / (TimeToMaxHeight * TimeToMaxHeight);
        _rigidbody.gravityScale = grav / 9.81f * (1 + 0.25f * JumpCount);
    }

    void OnLanding()
    {
      
        JumpCount = 0;
        _rigidbody.gravityScale = 1;

        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);
        var playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.OnLanding();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnLanding();
        }
    }
}
