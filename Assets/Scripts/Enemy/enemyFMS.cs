using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFMS : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float timeToChange = 4f;
    public bool isRight = false;
    public bool CanMove = true; // Nueva bandera para controlar el movimiento
    public float attackDistance = 0.5f; // Distancia para iniciar el ataque

    private Vector3 initialScale;
    private float timer;
    private Enemy enemy;

    void Start()
    {
        timer = timeToChange;
        initialScale = transform.localScale;
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (CanMove)
        {
            MoveTowardsPlayer();
        }
        else
        {
            CheckAttack();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calcula la dirección desde el enemigo hacia el jugador
        Vector3 heading = player.transform.position - transform.position;

        // Voltea la escala horizontalmente si el jugador está a la izquierda
        if (heading.x < 0)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            transform.localScale = initialScale;
        }

        // Mueve al enemigo hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // Comprueba si está en la distancia de ataque
        if (Vector2.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            CanMove = false;
            enemy.Attack();
        }
    }

    private void CheckAttack()
    {
        // Comprueba si está en la distancia de ataque
        if (Vector2.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            enemy.Attack();
        }
        else
        {
            CanMove = true;
        }
    }
}
