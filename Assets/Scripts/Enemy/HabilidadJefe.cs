using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    [SerializeField] private float da�o;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;
    [SerializeField] private float tiempoDeVida;
    
    void Start()
    {
        Destroy(gameObject,tiempoDeVida);
    }
    public void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapAreaAll(posicionCaja.position, dimensionesCaja, 0f);
        foreach (var colisiones in objetos)
        {
            if (colisiones.CompareTag("Player"))
            {
                colisiones.GetComponent<PlayerLive>().PlayerTakeDamage(da�o); ;
            }
        }
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
