using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator EnemyAnimator;
    public EnemyFMS EnemyMovement; 
    public int Health = 3;

    private void Start()
    {
        if (EnemyMovement == null)
        {
            EnemyMovement = GetComponent<EnemyFMS>();
        }
    }

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
}
