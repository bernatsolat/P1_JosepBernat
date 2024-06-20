using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioManager audioManager;
    public Animator EnemyAnimator;
    public EnemyFMS EnemyMovement;
    private int Health = 3;
    public float AttackRange = 0.5f;
    public int AttackDamage = 1;
    public LayerMask PlayerLayer;

    private bool isAttacking = false;
    private bool takingDamage = false;

    private void Start()
    {
        if (EnemyMovement == null)
        {
            EnemyMovement = GetComponent<EnemyFMS>();
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void EnemyTakeDamage(int damage)
    {
        takingDamage = true;
        if (EnemyMovement != null)
        {
            EnemyMovement.CanMove = false;
        }

        audioManager.PlaySFX(audioManager.enemyDamaged);
        EnemyAnimator.SetTrigger("Hurt");
        Health -= damage;

        if (Health <= 0)
        {
            EnemyAnimator.SetBool("Dead", true);
            Invoke("Die", 0.8f);
        }
        else
        {
            Invoke("EnableMovement", 0.5f);
        }
    }

    private void EnableMovement()
    {
        if (EnemyMovement != null)
        {
            EnemyMovement.ResumeAfterDamage();
            takingDamage = false;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        if (!isAttacking && !takingDamage)
        {
            isAttacking = true;
            EnemyMovement.CanMove = false;
            EnemyAnimator.SetTrigger("Attack");
            Invoke("DealDamage", 0.667f);
        }
    }

    private void DealDamage()
    {
        if (!takingDamage)
        {
            Vector2 position = transform.position;
            Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, AttackRange, PlayerLayer);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    PlayerLive player = hit.collider.GetComponent<PlayerLive>();
                    if (player != null)
                    {
                        player.PlayerTakeDamage(AttackDamage);
                    }
                }
            }
        }
        FinishAttack();
    }

    private void FinishAttack()
    {
        isAttacking = false;
        EnemyMovement.OnAttackComplete();
    }
}
