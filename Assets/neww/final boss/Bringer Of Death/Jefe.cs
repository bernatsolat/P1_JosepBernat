using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class Jefe : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform jugador;

    private bool mirandoDerecha = true;
    [Header("Vida")]

    [SerializeField] private float vida;

    [SerializeField] private BarraDeVida barraDeVida;

    private void Start() {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    public void EnemyTakeDamage(float daño)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            animator.SetTrigger("Death");
        
        }
    }

    private void Death() 
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            {
                mirandoDerecha = !mirandoDerecha;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
        }
     }
}
