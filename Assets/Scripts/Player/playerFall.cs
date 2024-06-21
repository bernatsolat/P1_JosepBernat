using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFall : MonoBehaviour
{

    private PlayerLive playerLive;

    private void Start()
    {
        playerLive = FindObjectOfType<PlayerLive>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerLive.Health = 0;
            Debug.Log("El personaje ha caído al vacío");
            playerLive.HasTodie(); 
        }
    }

}
