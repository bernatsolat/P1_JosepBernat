using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFall : MonoBehaviour
{

    private PlayerLive playerLive;

    private void Start()
    {
        // Encuentra la instancia de PlayerLive en el GameObject del jugador.
        playerLive = FindObjectOfType<PlayerLive>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El personaje ha ca�do al vac�o
            Debug.Log("El personaje ha ca�do al vac�o");
            playerLive.HasTodie(); // Llama directamente al m�todo HasTodie()
        }
    }

}
