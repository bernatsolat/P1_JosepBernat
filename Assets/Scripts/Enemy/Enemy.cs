using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator EnemyAnimator;
    public EnemyFMS EnemyMovement; // Referencia al script EnemyFMS
    public int Health = 3;

    private void Start()
    {
        // Aseg�rate de que EnemyMovement est� asignado
        if (EnemyMovement == null)
        {
            EnemyMovement = GetComponent<EnemyFMS>();
        }
    }

    public void TakeDamage(int damage)
    {
        if (EnemyMovement != null)
        {
            EnemyMovement.CanMove = false; // Deshabilitar el movimiento
        }

        EnemyAnimator.SetTrigger("Hurt");
        Health -= damage;

        if (Health <= 0)
        {
            EnemyAnimator.SetBool("Dead", true);
            Invoke("Die", 0.8f); // Desactivar despu�s de 0.8 segundos
        }
        else
        {
            Invoke("EnableMovement", 0.5f); // Volver a habilitar el movimiento despu�s de la animaci�n de da�o
        }
    }

    private void EnableMovement()
    {
        if (EnemyMovement != null)
        {
            EnemyMovement.CanMove = true; // Volver a habilitar el movimiento
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
