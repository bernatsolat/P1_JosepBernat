using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFMS : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float timeToChange = 4f;
    public bool isRight = false;

    private Vector3 initialScale;
    private float timer;

    void Start()
    {
        timer = timeToChange;
        initialScale = transform.localScale;
    }

    void Update()
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
    }
}