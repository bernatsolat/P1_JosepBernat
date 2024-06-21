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

    [SerializeField] private int vida;
    [SerializeField] private int maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;

    [Header("Ataque")]

    [SerializeField] private Transform controladorAtaque;

    [SerializeField] private float radioAtaque;
    [SerializeField] private int dañoAtaque;


    private void Start()
    {
        vida = maximoVida;
        animator = GetComponent<Animator>();
         rb2D = GetComponent<Rigidbody2D>();

        if (barraDeVida != null)
        {
            barraDeVida.InicializarBarraDeVida(vida);
        }
        else
        {
            Debug.LogError("BarraDeVida is not assigned.");
        }

        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("DPlayer", distanciaJugador);
    }


public void JefeTakeDamage(int daño)
    {
        vida -= daño;
        if (barraDeVida != null)
        {
            barraDeVida.CambiarVidaActual(vida);
        }
        else
        {
            Debug.LogError("BarraDeVida is not assigned.");
        }

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
    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<PlayerLive>().PlayerTakeDamage(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }

}
