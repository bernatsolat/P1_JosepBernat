using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float Speed;
    public float SprintSpeed;

    [Header("Jumping")]
    public float JumpHeight;
    public float TimeToMaxHeight;
    public int MaxJumps = 4;

    [Header("Attacking")]
    public float AttackRange;
    public int AttackDamage;
    public LayerMask EnemyLayer;

    private Rigidbody2D _rigidbody;
    private CollisionDetection _collisionDetection;
    private float _horizontal;
    private bool _isAttacking = false;
    private bool _isJumping = false;
    private int _jumpCount = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();

        PhysicsMaterial2D noFrictionMaterial = new PhysicsMaterial2D { friction = 0 };
        GetComponent<BoxCollider2D>().sharedMaterial = noFrictionMaterial;
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimation();
    }

    private void FixedUpdate()
    {
        if (!_isAttacking)
        {
            _rigidbody.velocity = new Vector2(_horizontal * (_horizontal != 0 && Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : Speed), _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void HandleInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }

        if (!_isAttacking && !_isJumping && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void HandleMovement()
    {
        if (_horizontal < 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (_horizontal > 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    private void HandleAnimation()
    {
        if (!_isAttacking && !_isJumping)
        {
            if (Mathf.Abs(_horizontal) > 0.0f)
            {
                PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Walk);
            }
            else
            {
                PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);
            }
        }
    }

    private void Attack()
    {
        _isAttacking = true;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Attack);
        Invoke("DealDamageToEnemy", 0.1f); // Assuming 0.1 seconds for the attack animation to reach the hit point
        Invoke("FinishAttack", 0.5f); // Assuming 0.5 seconds for the complete attack animation duration
    }

    private void DealDamageToEnemy()
    {
        Vector2 position = transform.position;
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, AttackRange, EnemyLayer);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                hit.collider.GetComponent<Enemy>().EnemyTakeDamage(AttackDamage);
            }
        }
    }

    private void FinishAttack()
    {
        _isAttacking = false;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 position = transform.position;
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        Gizmos.DrawLine(position, position + direction * AttackRange);
    }

    private void TryJump()
    {
        if (CanJump())
        {
            OnJump();
        }
    }

    private bool CanJump()
    {
        return (_collisionDetection.IsGrounded || _jumpCount < MaxJumps) && !_isAttacking;
    }

    private void OnJump()
    {
        _isJumping = true;
        SetGravity();

        float jumpForce = GetJumpForce();
        if (float.IsNaN(jumpForce))
        {
            Debug.LogWarning("Jump force is NaN. Check your JumpHeight and TimeToMaxHeight values.");
            return;
        }

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        _jumpCount++;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Jump);
    }

    private float GetJumpForce()
    {
        return (2 * JumpHeight / TimeToMaxHeight);
    }

    private void SetGravity()
    {
        float gravity = 2 * JumpHeight / (TimeToMaxHeight * TimeToMaxHeight);
        if (float.IsNaN(gravity))
        {
            Debug.LogWarning("Gravity is NaN. Check your JumpHeight and TimeToMaxHeight values.");
            return;
        }

        _rigidbody.gravityScale = gravity / 9.81f * (1 + 0.25f * _jumpCount);
    }

    public void OnLanding()
    {
        _isJumping = false;
        _jumpCount = 0;
        _rigidbody.gravityScale = 1;
        if (Mathf.Abs(_horizontal) > 0.0f)
        {
            PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Walk);
        }
        else
        {
            PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnLanding();
        }
    }
}
