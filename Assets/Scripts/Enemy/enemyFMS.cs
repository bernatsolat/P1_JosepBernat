using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFMS : MonoBehaviour
{
    public float speed;
    public GameObject player;

    public bool isRight = false;
    public bool CanMove = true; // Nueva bandera para controlar el movimiento
    public float attackDistance = 0.5f; // Distancia para iniciar el ataque
    public float patrolRange = 5f; // Rango de patrulla
    public Transform leftPatrolPoint; // Punto de patrulla izquierdo
    public Transform rightPatrolPoint; // Punto de patrulla derecho

    private Vector3 initialScale;
    private Enemy enemy;
    private bool isPatrolling = true; // Bandera para indicar si el enemigo está patrullando
    private Vector3 targetPosition; // Posición objetivo para la patrulla

    void Start()
    {
        initialScale = transform.localScale;
        enemy = GetComponent<Enemy>();
        SetNextPatrolPosition();
    }

    void Update()
    {
        if (CanMove)
        {
            if (isPatrolling)
            {
                Patrol();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    private void Patrol()
    {
        // Si el enemigo llega al punto de patrulla, establece el siguiente punto como objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNextPatrolPosition();
        }

        // Mueve al enemigo hacia el punto de patrulla
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void SetNextPatrolPosition()
    {
        // Elige aleatoriamente entre los puntos de patrulla izquierdo y derecho
        if (Random.Range(0f, 1f) > 0.5f)
        {
            targetPosition = leftPatrolPoint.position;
            FlipSprite(false); // Voltea a la izquierda
        }
        else
        {
            targetPosition = rightPatrolPoint.position;
            FlipSprite(true); // Voltea a la derecha
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calcula la dirección desde el enemigo hacia el jugador
        Vector3 heading = player.transform.position - transform.position;

        // Voltea la escala horizontalmente si el jugador está a la izquierda
        if (heading.x < 0)
        {
            FlipSprite(false); // Voltea a la izquierda
        }
        else
        {
            FlipSprite(true); // Voltea a la derecha
        }

        // Mueve al enemigo hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // Comprueba si está en la distancia de ataque
        if (Vector2.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            CanMove = false;
            enemy.Attack();
        }
        else if (Vector2.Distance(transform.position, player.transform.position) > patrolRange)
        {
            // Si el jugador está fuera del rango de patrulla, vuelve a patrullar
            isPatrolling = true;
        }
    }

    private void FlipSprite(bool facingRight)
    {
        if (facingRight)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
    }
}
