using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator EnemyAnimator;
<<<<<<< Updated upstream
    public EnemyFMS EnemyMovement; 
    public int Health = 3;

    private void Start()
    {
      
        if (EnemyMovement == null)
        {
            EnemyMovement = GetComponent<EnemyFMS>();
        }
    }

=======
    public int Health = 3;
    public float AttackRange;
    public int AttackDamage;
    public LayerMask PlayerLayer;
>>>>>>> Stashed changes
    public void TakeDamage(int damage)
    {
        if (EnemyMovement != null)
        {
            EnemyMovement.CanMove = false; 
        }

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
            EnemyMovement.CanMove = true; 
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
<<<<<<< Updated upstream
=======

    private void DealDamage()
    {
        Vector2 position = transform.position;
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, AttackRange, PlayerLayer);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                EnemyAnimator.SetTrigger("attack");
                hit.collider.GetComponent<PlayerMovement>().TakeDamage(AttackDamage);
            }
        }
    }
>>>>>>> Stashed changes
}
