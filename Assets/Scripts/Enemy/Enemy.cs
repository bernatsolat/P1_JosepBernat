using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static Enemy instance;
    public static Enemy Instance
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<Enemy>();
            return instance;
        }
    }
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
            Invoke("Die", 1f);

        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public int getHealth()
    {
        return Health;
    }
}
