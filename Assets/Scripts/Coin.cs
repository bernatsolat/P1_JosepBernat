
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioManager audioManager;
    public int valor = 1;
    public GameManager gameManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.coinCollect);
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }

    }
}