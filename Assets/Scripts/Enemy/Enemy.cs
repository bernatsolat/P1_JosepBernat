using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator EnemyAnimator;
    private string damagedEnemy = "damaged";
    public int Health = 3;
    
    public void TakeDamage(int damage)
    {
        EnemyAnimator.SetTrigger("Hurt");
        Health -= damage;
        if (Health <= 0)
        {

            EnemyAnimator.SetBool("Dead",true);
            Invoke("Die", 0.8f);

        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
