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
            // El personaje ha caído al vacío
            Debug.Log("El personaje ha caído al vacío");
            playerLive.HasTodie(); // Llama directamente al método HasTodie()
        }
    }

}
