using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float SprintSpeed;

    public float AttackRange;
    public int AttackDamage;
    public LayerMask EnemyLayer;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private int Health = 5;
    private bool IsAttacking = false;
    private bool IsJumping = false;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        PhysicsMaterial2D noFrictionMaterial = new PhysicsMaterial2D();
        noFrictionMaterial.friction = 0;

        GetComponent<BoxCollider2D>().sharedMaterial = noFrictionMaterial;
    }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (!IsAttacking && !IsJumping)
        {
            if (Horizontal < 0.0f)
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            else if (Horizontal > 0.0f)
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            if (Mathf.Abs(Horizontal) > 0.0f)
            {
                PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Walk);
            }
            else
            {
                PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!IsAttacking)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Rigidbody2D.velocity = new Vector2(Horizontal * SprintSpeed, Rigidbody2D.velocity.y);
            }
            else
            {
                Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
            }
        }
        else
        {
            Rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void Attack()
    {
        IsAttacking = true;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Attack);
        Invoke("DealDamage", 0.1f); // Assuming 0.1 seconds for the attack animation to reach the hit point
        Invoke("FinishAttack", 0.5f); // Assuming 0.5 seconds for the complete attack animation duration
    }

    private void DealDamage()
    {
        Vector2 position = transform.position;
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, AttackRange, EnemyLayer);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(AttackDamage);
            }
        }
    }

    private void FinishAttack()
    {
        IsAttacking = false;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 position = transform.position;
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        Gizmos.DrawLine(position, position + direction * AttackRange);
    }

    public void OnLanding()
    {
        IsJumping = false;
        if (Mathf.Abs(Horizontal) > 0.0f)
        {
            PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Walk);
        }
        else
        {
            PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);
        }
    }

    public void OnJump()
    {
        IsJumping = true;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Jump);
    }
}
*/