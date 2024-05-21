using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator EnemyAnimator;
    public EnemyFMS EnemyMovement; // Referencia al script EnemyFMS
    public int Health = 3;
    public float AttackRange = 0.5f;
    public int AttackDamage = 1;
    public LayerMask PlayerLayer;

    private void Start()
    {
        // Asegúrate de que EnemyMovement esté asignado
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
            Invoke("Die", 0.8f); // Desactivar después de 0.8 segundos
        }
        else
        {
            Invoke("EnableMovement", 0.5f); // Volver a habilitar el movimiento después de la animación de daño
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

    public void Attack()
    {
        EnemyAnimator.SetTrigger("Attack");
        Invoke("DealDamage", 0.1f); // Ajusta el tiempo según la animación de ataque
    }

    private void DealDamage()
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
                    player.TakeDamage(AttackDamage);
                }
            }
        }
    }
}
